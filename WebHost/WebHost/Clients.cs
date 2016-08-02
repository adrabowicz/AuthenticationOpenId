using CommonModule;
using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHost
{
    class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    ClientName = "KP MVC App - User",
                    ClientId = "Kp-MvcApp-User",

                    Flow = Flows.Implicit,
                    Enabled = true,

                    // allowed redirect Uris
                    RedirectUris = new List<string>
                    {
                        Config.KpMvcAppBaseIp
                    },

                    // by default the OIDC middleware asks for two scopes: openid and profile
                    AllowedScopes = new List<string>
                    {
                        "openid", "profile", "facility.read", "inventory.read", "inventory.readwrite"
                    }
                }
            };
        }
    }
}
