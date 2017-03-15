using System;
using Owin;
using IdentityServer3.Core.Configuration;
using Configuration;

namespace ServerHost
{
    class Startup
    {
        // IAppBuilder is an interface we can use to compose the application for Katana to host
        // Use, Map, Run or UseCookieAuthentication are all extension methods for IAppBuildere
        // they call logic that manipulates the current OWIN context or environment
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                var identityServerOptions = new IdentityServerOptions
                {
                    SiteName = "Console IdentityServer",
                    SigningCertificate = CertHelper.LoadCertificate($@"{AppDomain.CurrentDomain.BaseDirectory}"),

                    Factory = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get()),

                    RequireSsl = false
                };
                idsrvApp.UseIdentityServer(identityServerOptions);
            });
        }
    }
}
