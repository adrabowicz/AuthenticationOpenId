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
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,

                new Scope
                {
                    Name = "write",
                    DisplayName = "Write User Data"
                },
                new Scope
                {
                    Name = "read",
                    DisplayName = "Read User Data"
                },
                new Scope
                {
                    Name = "cidm_identity"
                },
                new Scope
                {
                    Name = "cidm_permissions"
                },
                new Scope
                {
                    Name = "common_menu"
                },
                new Scope
                {
                    Name = "user_info"
                },
                new Scope
                {
                    Name = "med_data"
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
