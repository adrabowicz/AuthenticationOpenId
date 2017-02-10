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
                "ma_app",
               "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob_med_reader", "secret", "med_data.read").Result;
        }

        private static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            var url = Config.KpApiBaseIP + "/med-data/15";
            Console.WriteLine(client.GetStringAsync(url).Result);
        }
    }
}
