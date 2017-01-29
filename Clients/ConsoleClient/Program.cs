﻿using System;
using System.Net.Http;
using IdentityModel.Client;
using Configuration;

namespace KpServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // request an access token on behalf of a user
            var response = GetUserToken(Config.IdentityServerConnectTokenIp);
            // call the API using the access token
            CallApi(response, Config.MkpApiTestIp);
        }

        static void CallApi(TokenResponse response, string apiUrl)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync(apiUrl).Result);
        }
        

        static TokenResponse GetUserToken(string identityServerConnectTokenUrl)
        {
            var client = new TokenClient(
                identityServerConnectTokenUrl,
                "ma_med_reader",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("ma_med_reader", "secret", "cidm_permissions.read, common_menu.read, med.read").Result;
        }
    }
}
