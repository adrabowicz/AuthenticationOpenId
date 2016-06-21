using Owin;
using IdentityServer3.Core.Configuration;

namespace ServerHost
{
    class Startup
    {
        // IAppBuilder is an interface we can use to compose the application for Katana to host
        // Use, Map, Run or UseCookieAuthentication are all extension methods for IAppBuildere
        // they call logic that manipulates the current OWIN context or environment
        public void Configuration(IAppBuilder app)
        {
            var options = new IdentityServerOptions
            {
                SiteName = "Embedded IdentityServer",

                Factory = new IdentityServerServiceFactory()
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get())
                            .UseInMemoryUsers(Users.Get()),

                RequireSsl = false
            };

            // Map - if the request path starts with the given pathMatch, execute the app configured via configuration parameter 
            // instead of continuing to the next component in the pipeline

            // IdentityServer extension method on IAppBuilder that 
            // allows setting up IdentityServer in the OWIN host
            // Use - inserts a middleware into the OWIN pipeline that has a next middleware reference
            app.UseIdentityServer(options);
        }
    }
}
