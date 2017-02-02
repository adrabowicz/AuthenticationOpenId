using System;
using System.Net.Http;
using IdentityModel.Client;
using Configuration;

namespace KpServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // request the access token using the client credentials
            var response = GetClientToken(Config.IdentityServerConnectTokenIP);
            // call the API using the access token
            CallApi(response, Config.CidmApiTestIp);

            // request an access token on behalf of a user
            response = GetUserToken(Config.IdentityServerConnectTokenIP);
            // call the API using the access token
            CallApi(response, Config.KpApiTestIP);
        }

        static void CallApi(TokenResponse response, string apiUrl)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);
            var result = client.GetStringAsync(apiUrl).Result;
            Console.WriteLine(result);
        }

        static TokenResponse GetClientToken(string identityServerConnectTokenUrl)
        {
            var client = new TokenClient(
                identityServerConnectTokenUrl,
                "idm",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("cidm_identity.read").Result;
        }

        static TokenResponse GetUserToken(string identityServerConnectTokenUrl)
        {
            var client = new TokenClient(
                identityServerConnectTokenUrl,
                "med_reader",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("med_reader", "secret", "cidm_permissions.read, common_menu.read, med_data.read").Result;
        }
    }
}
