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
                    Name = "cidm_identity.read"
                },
                new Scope
                {
                    Name = "cidm_permissions.read"
                },
                new Scope
                {
                    Name = "common_menu.read"
                },
                new Scope
                {
                    Name = "med_data.read"
                },
                new Scope
                {
                    Name = "med_data.write"
                },
                new Scope
                {
                    Name = "infusion.read"
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
