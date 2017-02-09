using System.Security.Claims;
using System.Web.Http;
using IdentityModel.Client;
using Thinktecture.IdentityModel.WebApi;

namespace MkpApi.Controllers
{
  //  [ScopeAuthorize("med_data.read")]
    public class MedReadController : ApiController
    {
        [Route("med-data-read")]
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            var subjectClaim = caller.FindFirst("sub");
            if (subjectClaim != null)
            {
                return Json(new
                {
                    message = "OK user",
                    client = caller.FindFirst("client_id").Value,
                    subject = subjectClaim.Value
                });
            }
            else
            {
                return Json(new
                {
                    message = "OK computer",
                    client = caller.FindFirst("client_id").Value
                });
            }
        }

        private static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "med_data_service",
                "C307B573-1B25-4DF5-8AC7-E7f25A43C229");

            return client.RequestClientCredentialsAsync("cidm_permissions.read").Result;
        }
    }
}
