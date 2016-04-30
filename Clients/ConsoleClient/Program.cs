using IdentityModel.Client;
using System;
using System.Net.Http;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // request the access token using the client credentials
            var response = GetClientToken();
            // call the API using the access token:
            CallApi(response);

            //response = GetUserToken();
            //CallApi(response);
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:6472/test").Result);
        }

        static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("MKP").Result;
        }

        static TokenResponse GetUserToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "carbon",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "MKP").Result;
        }
    }
}
