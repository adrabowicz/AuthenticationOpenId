using System.Security.Claims;
using System.Web.Http;
using System.Net.Http;
using IdentityModel.Client;
using Configuration;

namespace Shared
{
    public class BaseApiController : ApiController
    {
        protected string AuthorizeUser()
        {
            var caller = User as ClaimsPrincipal;
            return caller?.FindFirst("sub")?.Value;
         }

        protected string GetAppDataFromCidm(string clientName, string clientSecret, string userId)
        {
            return GetDataFromCidm(clientName, clientSecret, userId, "permissions", "cidm_permissions_api");
        }

        protected string GetUserDataFromCidm(string clientName, string clientSecret, string userId)
        {
            return GetDataFromCidm(clientName, clientSecret, userId, "identity", "cidm_identity_api");
        }

        private string GetDataFromCidm(string clientName, string clientSecret, string userId, string api, string scope)
        {
            var httpClient = SharedHttpClient.GetHttpClient(clientName, clientSecret, scope);

            var url = Config.CidmApiBaseIP + "/" + api + "/" + userId;
            var aegisData = httpClient.GetStringAsync(url).Result;
            return aegisData;
        }
    }
}
