using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace Configuration
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            var scopes = new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.OfflineAccess,

                new Scope
                {
                    Name = "cidm_identity_api"
                },
                new Scope
                {
                    Name = "cidm_permissions_api"
                },
                new Scope
                {
                    Name = "common_menu_api"
                },
                new Scope
                {
                    Name = "user_info_api"
                },
                new Scope
                {
                    Name = "med_data_api"
                },
                new Scope
                {
                    Enabled = true,
                    Name = "roles",
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                }
            };

            scopes.AddRange(StandardScopes.All);

            return scopes;
        }
    }
}
