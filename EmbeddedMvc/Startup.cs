using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core;
using Configuration;

namespace EmbeddedMvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // turn off mapping of claims to .NET ClaimTypes
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            // configuration for anti-CSRF protection
            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;

            // if the request path starts with "/identity", execute the app configured via configuration parameter 
            // instead of continuing to the next component in the pipeline
            app.Map("/identity", idsrvApp =>
            {
                var identityServerOptions = new IdentityServerOptions
                {
                    SiteName = "Embedded IdentityServer",
                    SigningCertificate = CertHelper.LoadCertificate(),

                    Factory = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get())
                };
                idsrvApp.UseIdentityServer(identityServerOptions);
            });

            // configure OWIN middleware
            // OWIN middleware sits in the pipeline and operates independently, has no knowledge of MVC
            // configured using IAppBuilder
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            // claims transformation
            var notifications = new OpenIdConnectAuthenticationNotifications
            {
                SecurityTokenValidated = n =>
                {
                    var id = n.AuthenticationTicket.Identity;

                    // we want to keep first name, last name, subject and roles
                    var givenName = id.FindFirst(Constants.ClaimTypes.GivenName);
                    var familyName = id.FindFirst(Constants.ClaimTypes.FamilyName);
                    var sub = id.FindFirst(Constants.ClaimTypes.Subject);
                    var roles = id.FindAll(Constants.ClaimTypes.Role);

                    // create new identity and set name and role claim type
                    var newIdentity = new ClaimsIdentity(
                        id.AuthenticationType,
                        Constants.ClaimTypes.GivenName,
                        Constants.ClaimTypes.Role);

                    newIdentity.AddClaim(givenName);
                    newIdentity.AddClaim(familyName);
                    newIdentity.AddClaim(sub);
                    newIdentity.AddClaims(roles);

                    // add some other app specific claim
                    newIdentity.AddClaim(new Claim("app_specific", "some data"));

                    n.AuthenticationTicket = new AuthenticationTicket(newIdentity, n.AuthenticationTicket.Properties);

                    return Task.FromResult(0);
                }
            };

            // do things related to OpenID Connect flows
            var openIdConnectOptions = new OpenIdConnectAuthenticationOptions
            {
                Authority = ConfigSSL.IdentityServerIdentityIP,
                ClientId = "mvc",
                Scope = "openid profile roles",
                RedirectUri = ConfigSSL.IdentityServerBaseIP,
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false,

                // notification that you can use to do claims transformation
                // the resulting claims will be stored in the cookie
                Notifications = notifications
            };
            app.UseOpenIdConnectAuthentication(openIdConnectOptions);
        }
    }
}
