using System.Security.Claims;
using System.Web.Http;
using IdentityModel.Client;
using System.Net.Http;

namespace Configuration
{
    public class BaseApiController : ApiController
    {
        protected string AuthorizeUser()
        {
            var caller = User as ClaimsPrincipal;
            return caller?.FindFirst("sub")?.Value;
         }

        protected string GetUserPermissionsFromCidm(string clientName, string clientSecret, string userId)
        {
            var tokenClient = new TokenClient(
                Config.IdentityServerTokenIp,
                clientName,
                clientSecret);

            var response = tokenClient.RequestClientCredentialsAsync("cidm_permissions").Result;

            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            var url = Config.CidmApiBaseIp + "/permissions/" + userId;
            var aegisPermissions = client.GetStringAsync(url).Result;
            return aegisPermissions;
        }
    }
}
