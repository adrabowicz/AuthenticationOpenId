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
                    Username = "ma_med_reader",
                    Password = "secret",
                    Subject = "ma_med_reader_id",

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "ma_med_reader"),
                        new Claim(Constants.ClaimTypes.FamilyName, "ma_med_reader")
                    }
                },
                new InMemoryUser
                {
                    Username = "ma_med_reader_writer",
                    Password = "secret",
                    Subject = "ma_med_reader_writer_id",
                },
                new InMemoryUser
                {
                    Username = "bemchmarking_med_infusion_reader",
                    Password = "secret",
                    Subject = "bemchmarking_med_infusion_reader_id",
                }
            };
        }
    }
}