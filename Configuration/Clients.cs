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
                    ClientName = "IDM",
                    ClientId = "idm",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "cidm_identity.read"
                    }
                },
                new Client
                {
                    ClientName = "MA",
                    ClientId = "ma",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,
                    
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "cidm_permissions.read", "common_menu.read", "med.read", "med.readwrite"
                    }
                },
                new Client
                {
                    ClientName = "Benchmarking",
                    ClientId = "benchmarking",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("C9195B0E-E5B1-4ADE-A650-DB86322BB7A2".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "cidm_permissions.read", "common_menu.read", "med.read", "infusion.read"
                    }
            };
        }
    }
}