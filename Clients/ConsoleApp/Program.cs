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
            var accessToken = GetAccessToken(clientId: "ma_app", clientSecret: "21B5F798-BE55-42BC-8AA8-0025B903DC3B", scope: "common_menu.read");
            var url = Config.CommonApiBaseIP + "/menu/ma_app";
            var result = MakeApiCallToGetData(accessToken, url);
            Console.WriteLine("Data received from Common Menu Service: " + result);

            // get med data
            accessToken = GetAccessToken(clientId: "ma_app", clientSecret: "21B5F798-BE55-42BC-8AA8-0025B903DC3B", scope: "med_data.read");
            url = Config.KpApiBaseIP + "/med-data/15";
            result = MakeApiCallToGetData(accessToken, url);
            Console.WriteLine("Data received from Med Data Service: " + result);

            Console.Read();
        }

        private static string MakeApiCallToGetData(string accessToken, string url)
        {
            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            return client.GetStringAsync(url).Result;
        }

        private static string GetAccessToken(string clientId, string clientSecret, string scope)
        {
            var client = new TokenClient("http://localhost:5000/connect/token", clientId, clientSecret);
            return client.RequestResourceOwnerPasswordAsync("bob_med_reader", "secret", scope).Result.AccessToken;
        }
    }
}
