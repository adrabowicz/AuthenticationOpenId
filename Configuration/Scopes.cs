using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace Configuration
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
            {
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
                }
            };
        }
    }
}
