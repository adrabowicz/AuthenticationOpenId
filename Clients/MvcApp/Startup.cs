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
//using IdentityServer3.Core.Configuration;
//using IdentityServer3.Core;
//using Configuration;

namespace MvcApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //// turn off mapping of claims to .NET ClaimTypes
            //JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            //// configuration for anti-CSRF protection
            //AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;

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
                ClientId = "mvc",
                Scope = "openid profile roles",
                RedirectUri = "https://localhost:44319/",
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
