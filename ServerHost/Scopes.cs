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
                    Name = "Org"
                },
                new Scope
                {
                    Name = "Device"
                },
                new Scope
                {
                    Name = "App"
                },
                new Scope
                {
                    Name = "Aegis"
                },
            };
        }
    }
}
