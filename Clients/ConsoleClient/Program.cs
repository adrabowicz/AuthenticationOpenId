﻿using IdentityModel.Client;
using System;
using System.Net.Http;

namespace KpServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // request the access token using the client credentials
            var response = GetClientToken();
            // call the API using the access token
            CallApi(response, "http://localhost:42204/test");

            // request an access token on behalf of a user
            response = GetUserToken();
            // call the API using the access token
            CallApi(response, "http://localhost:6472/test");
        }

        static void CallApi(TokenResponse response, string apiUrl)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync(apiUrl).Result);
        }

        static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "KP",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("aegis.read").Result;
        }

        static TokenResponse GetUserToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "KP-User",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "device.read").Result;
        }
    }
}
