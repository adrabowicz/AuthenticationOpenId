using System.Security.Claims;
using System.Web.Http;
using IdentityModel.Client;
using Thinktecture.IdentityModel.WebApi;
using System.Net.Http;
using Configuration;

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
            if (subjectClaim == null)
            {
                return Unauthorized();
            }

            var userId = subjectClaim.Value;

            var userAegisPermissions = Config.GetUserAegisPermissions("med_data_service", "C307B573-1B25-4DF5-8AC7-E7f25A43C229", userId);

            var authorized = AuthorizeResourceAccess(userAegisPermissions);

            if (!authorized)
            {
                return Unauthorized();
            }

            // access med data

            return Ok("med data");
        }

        private static bool AuthorizeResourceAccess(string userAegisPermissions)
        {
            return true;
        }
    }
}
