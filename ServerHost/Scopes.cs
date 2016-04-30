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
                    Name = "RKP"
                },
                new Scope
                {
                    Name = "MKP"
                }
            };
        }
    }
}
