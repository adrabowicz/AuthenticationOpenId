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
                    Name = "org.read"
                },
                new Scope
                {
                    Name = "device.read"
                },
                new Scope
                {
                    Name = "app.read"
                },
                 new Scope
                {
                    Name = "app.readwrite"
                },
                new Scope
                {
                    Name = "aegis.read"
                },
            };
        }
    }
}
