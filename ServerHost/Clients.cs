using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace ServerHost
{
    static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                // no human involved
                new Client
                {
                    ClientName = "KP Server App - Machine",
                    ClientId = "KP-Machine",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "aegis.read"
                    }
                },

                // human is involved
                new Client
                {
                    ClientName = "KP Server App - User",
                    ClientId = "KP-User",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "facility.read", "inventory.read", "inventory.readwrite"
                    }
                },

                new Client
                {
                    ClientName = "KP Browser App - User",
                    ClientId = "KP-BrowserUser",
                    Enabled = true,

                    Flow = Flows.Implicit,

                    // allowed redirect Uris
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44375/"
                    },

                    AllowedScopes = new List<string>
                    {
                        "facility.read", "inventory.read", "inventory.readwrite"
                    }
                }
            };
        }
    }
}