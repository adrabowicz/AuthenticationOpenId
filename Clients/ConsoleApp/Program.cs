using System;
using System.Net.Http;
using Configuration;
using IdentityModel.Client;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var response = GetClientToken();
            CallApi(response);
        }

        private static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "med_data_service",
                "C307B573-1B25-4DF5-8AC7-E7f25A43C229");

            return client.RequestClientCredentialsAsync("cidm_permissions.read").Result;
        }

        private static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync(Config.CidmApiBaseIP + "/permissions").Result);
        }
    }
}
