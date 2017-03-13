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
            var url = Config.CommonApiBaseIp + "/menu/ma_app";
            var result = MakeApiCallToGetData(accessToken, url);
            Console.WriteLine("Data received from Common Menu Service: " + result);

            // get med data
            accessToken = GetAccessToken(clientId: "ma_app", clientSecret: "21B5F798-BE55-42BC-8AA8-0025B903DC3B", scope: "med_data");
            url = Config.KpApiBaseIp + "/med-data/15";
            result = MakeApiCallToGetData(accessToken, url);
            Console.WriteLine("Data received from Med Data Service: " + result);

            Console.Read();
        }

        private static string GetAccessToken(string clientId, string clientSecret, string scope)
        {
            var client = new TokenClient(Config.IdentityServerTokenIp, clientId, clientSecret);
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
