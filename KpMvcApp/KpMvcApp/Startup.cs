using System.Security.Cryptography.X509Certificates;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Configuration;
using IdentityServer3.Core.Models;

namespace KpMvcApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //@todo
            //app.Map("/identity", idsrvApp =>
            //{
            //    idsrvApp.UseIdentityServer(new IdentityServerOptions
            //    {
            //        SiteName = "Embedded IdentityServer",
            //        RequireSsl = false,
            //        SigningCertificate = LoadCertificate(),

            //        Factory = new IdentityServerServiceFactory()
            //                    .UseInMemoryUsers(Users.Get())
            //                    .UseInMemoryClients(Clients.Get())
            //                    .UseInMemoryScopes(StandardScopes.All)
            //    });
            //});

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = "Cookies"
            //});

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = Config.IdentityServerIdentityIP,
                ClientId = "KP-BrowserUser",
                RedirectUri = Config.KpMvcAppBaseIP,
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies"
            });
        }

        private static X509Certificate2 LoadCertificate()
        {
            var path = @"C:\KP\Certificates\idsrv3test.pfx";
            return new X509Certificate2(path, "idsrv3test");
        }
    }
}
