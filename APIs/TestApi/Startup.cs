using System.Web.Http;
using Owin;
using IdentityServer3.AccessTokenValidation;
using Configuration;

namespace TestApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // configuration of HttpServer instance
            var config = new HttpConfiguration();
            // map the attribute-defined routes for the application
            config.MapHttpAttributeRoutes();

            // plug OWIN middleware component for WebApi into the pipeline
            app.UseWebApi(config);
        }
    }
}