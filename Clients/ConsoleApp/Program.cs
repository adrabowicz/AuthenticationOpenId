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
            // get med data
            var accessToken = GetAccessToken("ma_app", "21B5F798-BE55-42BC-8AA8-0025B903DC3B", "med_data.read");
            var url = Config.KpApiBaseIP + "/med-data/15";
            CallApi(accessToken, url);
        }

        private static string GetAccessToken(string clientId, string clientSecret, string scope)
        {
            var client = new TokenClient("http://localhost:5000/connect/token", clientId, clientSecret);
            return client.RequestResourceOwnerPasswordAsync("bob_med_reader", "secret", scope).Result.AccessToken;
        }

        private static void CallApi(string accessToken, string url)
        {
            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            Console.WriteLine(client.GetStringAsync(url).Result);
        }
    }
}
