using System.Web.Http;
using Owin;
using IdentityServer3.AccessTokenValidation;
using Configuration;

namespace CommonApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'MKP'
            var tokenAuthenticationOptions = new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = Config.IdentityServerBaseIp,
                ValidationMode = ValidationMode.ValidationEndpoint,

                RequiredScopes = new[] { "common_menu.read" }
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
