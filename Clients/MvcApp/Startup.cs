using System.Collections.Generic;
using System.IdentityModel.Tokens;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Configuration;

namespace MvcApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // turn off mapping of claims to .NET ClaimTypes
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            // configure OWIN middleware
            // OWIN middleware sits in the pipeline and operates independently, has no knowledge of MVC
            // configured using IAppBuilder
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            // do things related to OpenID Connect flows
            var openIdConnectOptions = new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://localhost:44319/identity",
                ClientId = "mvc_app",
                Scope = "openid profile roles",
                RedirectUri = ConfigSSL.MvcAppBaseIP,
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false,

                // notification that you can use to do claims transformation
                // the resulting claims will be stored in the cookie
         //       Notifications = notifications
            };
            app.UseOpenIdConnectAuthentication(openIdConnectOptions);
        }
    }
}
