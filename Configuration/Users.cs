﻿using System.Security.Claims;
using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;

namespace Configuration
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            // Subject is the unique identifier for that user that will be embedded into the access token.
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "bob_med_reader",
                    Password = "secret",
                    Subject = "med_reader_id",

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "med_reader"),
                        new Claim(Constants.ClaimTypes.FamilyName, "med_reader")
                    }
                },
                new InMemoryUser
                {
                    Username = "bob",
                    Password = "secret",
                    Subject = "1",
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(Constants.ClaimTypes.Role, "Geek"),
                        new Claim(Constants.ClaimTypes.Role, "Foo")
                    }
                }
            };
        }
    }
}
