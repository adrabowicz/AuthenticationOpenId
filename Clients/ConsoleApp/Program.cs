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
            // get menu data
            var accessToken = GetAccessToken(clientId: "ma_app", clientSecret: "21B5F798-BE55-42BC-8AA8-0025B903DC3B", scope: "common_menu");
            var url = Config.CommonApiBaseIP + "/menu/ma_app";
            var result = MakeApiCallToGetData(accessToken, url);
            Console.WriteLine("Data received from Menu Service: " + result);

            // get user data
            accessToken = GetAccessToken(clientId: "ma_app", clientSecret: "21B5F798-BE55-42BC-8AA8-0025B903DC3B", scope: "user_info");
            url = Config.CommonApiBaseIP + "/user-info";
            result = MakeApiCallToGetData(accessToken, url);
            Console.WriteLine("Data received from User Info Service: " + result);

            // get med data
            accessToken = GetAccessToken(clientId: "ma_app", clientSecret: "21B5F798-BE55-42BC-8AA8-0025B903DC3B", scope: "med_data");
            url = Config.KpApiBaseIP + "/med-data/15";
            result = MakeApiCallToGetData(accessToken, url);
            Console.WriteLine("Data received from Med Data Service: " + result);

            Console.Read();
        }

        private static string GetAccessToken(string clientId, string clientSecret, string scope)
        {
            var client = new TokenClient(Config.IdentityServerTokenIP, clientId, clientSecret);
            var response = client.RequestResourceOwnerPasswordAsync("bob_med_reader", "secret", scope).Result;
            return response.AccessToken;
        }

        private static string MakeApiCallToGetData(string accessToken, string url)
        {
            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            return client.GetStringAsync(url).Result;
        }
    }
}
