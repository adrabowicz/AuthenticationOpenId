using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using Owin;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using IdentityModel.Client;
using Configuration;

[assembly: OwinStartup(typeof(MVC_OWIN_Client.Startup))]

namespace MVC_OWIN_Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            var openIdConnectOptions = GetOpenIdConnectAuthenticationOptions();

            app.UseOpenIdConnectAuthentication(openIdConnectOptions);
        }

        private static OpenIdConnectAuthenticationOptions GetOpenIdConnectAuthenticationOptions() {
            var openIdConnectOptions = new OpenIdConnectAuthenticationOptions
            {
                ClientId = "mvc.owin.hybrid",
                Authority = Config.IdentityServerIdentityIP,
                RedirectUri = Config.MvcHybridAppBaseIP,
                PostLogoutRedirectUri = Config.MvcHybridAppBaseIP,
                ResponseType = "code id_token",
                Scope = "openid common_menu user_info med_data",

                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                },

                SignInAsAuthenticationType = "Cookies",

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthorizationCodeReceived = async n =>
                    {
                        // use the code to get the access and refresh token
                        var tokenClient = new TokenClient(Config.IdentityServerTokenIP,
                                                          "mvc.owin.hybrid",
                                                          "36fe6589-fa3f-4459-a985-9dac65b4fa9d");

                        var tokenResponse = await tokenClient.RequestAuthorizationCodeAsync(n.Code, n.RedirectUri);

                        if (tokenResponse.IsError)
                        {
                            throw new Exception(tokenResponse.Error);
                        }

                        var id = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType);

                        id.AddClaim(new Claim("access_token", tokenResponse.AccessToken));

                        n.AuthenticationTicket = new AuthenticationTicket(
                            new ClaimsIdentity(id.Claims, n.AuthenticationTicket.Identity.AuthenticationType, "name", "role"),
                            n.AuthenticationTicket.Properties);
                    },

                    RedirectToIdentityProvider = n =>
                    {
                        // if signing out, add the id_token_hint
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                        {
                            var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                            if (idTokenHint != null)
                            {
                                n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                            }
                        }

                        return Task.FromResult(0);
                    }
                }
            };
            return openIdConnectOptions;
        }
    }
}