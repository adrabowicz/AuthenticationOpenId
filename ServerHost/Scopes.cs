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
                    Name = "facility.read"
                },
                new Scope
                {
                    Name = "inventory.read"
                },
                new Scope
                {
                    Name = "inventory.readwrite"
                },
                new Scope
                {
                    Name = "aegis.read"
                },
            };
        }
    }
}
