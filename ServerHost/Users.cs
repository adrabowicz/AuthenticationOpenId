using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;

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
                    Subject = "1"
                },
                new InMemoryUser
                {
                    Username = "alice",
                    Password = "secret",
                    Subject = "2"
                }
            };
        }
    }
}
