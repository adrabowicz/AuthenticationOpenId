using System.Collections.Generic;
using IdentityServer3.Core.Models;
using CommonModule;

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
                    ClientId = "Kp-Server-Machine",
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,
                    Enabled = true,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "aegis.read"
                    }
                },

                new Client
                {
                    ClientName = "KP Server App - User",
                    ClientId = "Kp-Server-User",
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,
                    Enabled = true,

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
                    ClientName = "KP MVC App - User",
                    ClientId = "Kp-Mvc-User",

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