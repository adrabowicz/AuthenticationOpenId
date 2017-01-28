using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace Configuration
{
    public static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "MA",
                    ClientId = "ma",
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,
                    Enabled = true,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "cidm_permissions.read", "common-menu.read", "med.read", "med.readwrite"
                    }
                }
            };
        }
    }
}