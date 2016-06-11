using Owin;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;

namespace MkpApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'MKP'
            var tokenAuthenticationOptions = new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                ValidationMode = ValidationMode.ValidationEndpoint,

                RequiredScopes = new[] { "facility.read", "inventory.read", "inventory.readwrite" }
            };

            // plug OWIN middleware component for token authentication into the pipeline
            app.UseIdentityServerBearerTokenAuthentication(tokenAuthenticationOptions);

            // configuration of HttpServer instance
            var config = new HttpConfiguration();
            // map the attribute-defined routes for the application
            config.MapHttpAttributeRoutes();
            // require authentication for all controllers
            config.Filters.Add(new AuthorizeAttribute());

            // plug OWIN middleware component for WebApi into the pipeline
            app.UseWebApi(config);
        }
    }
}