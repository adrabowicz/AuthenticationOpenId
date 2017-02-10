using System.Net.Http;
using IdentityModel.Client;

namespace Configuration
{
    public static class Config
    {
        public const string Protocol = "http://";

        public static string IdentityServerBaseIP = Protocol + "localhost:5000";
        public static string IdentityServerIdentityIP = IdentityServerBaseIP + "/identity";
        public static string IdentityServerConnectTokenIP = IdentityServerBaseIP + "/connect/token";

        public static string CidmApiBaseIP = Protocol + "localhost:42001";
        public static string CidmApiTestIp = CidmApiBaseIP + "/test";

        public static string CommonApiBaseIP = Protocol + "localhost:42002";
        public static string CommonApiTestIP = CommonApiBaseIP + "/test";

        public static string KpApiBaseIP = Protocol + "localhost:42003";
        public static string KpApiTestIP = KpApiBaseIP + "/test";

        public const string KpMvcAppBaseIP = "https://localhost:44375/";

        public static string GetUserAegisPermissions(string clientName, string clientSecret, string userId)
        {
            var tokenClient = new TokenClient(
                "http://localhost:5000/connect/token",
                clientName,
                clientSecret);

            var response = tokenClient.RequestClientCredentialsAsync("cidm_permissions.read").Result;

            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            var url = CidmApiBaseIP + "/permissions/" + userId;
            var aegisPermissions = client.GetStringAsync(url).Result;
            return aegisPermissions;
        }
    }
}
