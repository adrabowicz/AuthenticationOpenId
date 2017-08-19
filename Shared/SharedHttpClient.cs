using System.Net.Http;
using IdentityModel.Client;
using Configuration;

namespace Shared
{
    public static class SharedHttpClient
    {
        public static HttpClient GetHttpClient(string clientName, string clientSecret, string scope)
        {
            var accessToken = GetAccessToken(clientName, clientSecret, scope);
            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            return client;
        }

        public static string GetAccessToken(string clientName, string clientSecret, string scope)
        {
            var tokenClient = new TokenClient(
                Config.IdentityServerTokenIP,
                clientName,
                clientSecret);

            var response = tokenClient.RequestClientCredentialsAsync(scope).Result;

            return response.AccessToken;
        }
    }
}
