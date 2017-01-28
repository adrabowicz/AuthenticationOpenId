using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace ServerHost
{
    static class Scopes
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
                    Name = "common-menu.read"
                },
                new Scope
                {
                    Name = "med.read"
                },
                new Scope
                {
                    Name = "med.readwrite"
                },
                new Scope
                {
                    Name = "infusion.read"
                }
            };
        }
    }
}
