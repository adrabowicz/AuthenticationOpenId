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
                    ClientName = "MVC Client",
                    ClientId = "mvc",
                    Enabled = true,

                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:44319/"
                    },

                    AllowAccessToAllScopes = true
                },
                new Client
                {
                    ClientName = "IDM Service",
                    ClientId = "idm_service",
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
                    ClientName = "Common Menu Service",
                    ClientId = "common_menu_service",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("E901482E-8284-4A6B-889C-F40978934C89".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "cidm_permissions.read"
                    }
                },
                new Client
                {
                    ClientName = "Med Data Service",
                    ClientId = "med_data_service",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("C307B573-1B25-4DF5-8AC7-E7f25A43C229".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "cidm_permissions.read"
                    }
                },
                new Client
                {
                    ClientName = "MA App",
                    ClientId = "ma_app",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,
                    
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "common_menu.read", "med_data.read"
                    }
                },
                new Client
                {
                    ClientName = "Benchmarking App",
                    ClientId = "benchmarking_app",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("C9195B0E-E5B1-4ADE-A650-DB86322BB7A2".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "common_menu.read", "med_data.read", "infusion_data.read"
                    }
                }
            };
        }
    }
}