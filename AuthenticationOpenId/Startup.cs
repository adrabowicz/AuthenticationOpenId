using IdentityServer3.Core.Configuration;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationOpenId
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new IdentityServerOptions
            {
                //SigningCertificate = Certificate.Get(),
                //Factory = Factory.Create()
            };

            app.UseIdentityServer(options);
        }
    }
}
