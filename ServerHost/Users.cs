using System.Security.Claims;
using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;

namespace ServerHost
{
    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            // Subject is the unique identifier for that user that will be embedded into the access token.
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "bob",
                    Password = "secret",
                    Subject = "BobDatabaseKey",

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Smith")
                    }
                },
                new InMemoryUser
                {
                    Username = "alice",
                    Password = "secret",
                    Subject = "AliceDatabaseKey"
                }
            };
        }
    }
}
