using System.Collections.Generic;
using IdentityServer3.Core;
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
                    ClientName = "SPA App",
                    ClientId = "spa_app",
                    Enabled = true,

                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        "common_menu_api",
                        "user_info_api",
                        "med_data_api"
                    },

                    RedirectUris = new List<string>
                    {
                        Config.SpaRedirectUri
                    }
                },
                new Client
                {
                    ClientName = "Angular App",
                    ClientId = "angular_app",
                    Enabled = true,

                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "http://localhost:42030/popup.html",
                        "http://localhost:42030/silent-renew.html"
                    },

                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:42030/index.html"
                    },

                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:42030"
                    },

                    AllowedScopes = new List<string>
                    {
                        "common_menu_api",
                        "user_info_api",
                        "med_data_api"
                    },

                    AccessTokenLifetime = 60
                },
                new Client
                {
                    ClientName = "Console App",
                    ClientId = "ma_app",
                    Enabled = true,
                    RequireConsent = false,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "common_menu_api",
                        "user_info_api",
                        "med_data_api"
                    }
                },
                new Client
                {
                    ClientName = "MVC App",
                    ClientId = "mvc.owin.hybrid",
                    Enabled = true,
                    RequireConsent = false,

                    Flow = Flows.Hybrid,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("36fe6589-fa3f-4459-a985-9dac65b4fa9d".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.OfflineAccess,
                        "common_menu_api",
                        "user_info_api",
                        "med_data_api"
                    },
                    RedirectUris = new List<string>
                    {
                        Config.MvcHybridAppBaseIP
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                       Config.MvcHybridAppBaseIP
                    }
                },
                new Client
                {
                    ClientName = "Common Service",
                    ClientId = "common_service",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("E901482E-8284-4A6B-889C-F40978934C89".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "cidm_permissions_api",
                        "cidm_identity_api"
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
                        "cidm_permissions_api"
                    }
                }
            };
        }
    }
}