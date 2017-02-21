using System.Security.Claims;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;
using Configuration;

namespace MkpApi.Controllers
{
    [ScopeAuthorize("med_data.read")]
    public class MedReadController : ApiController
    {
        [Route("med-data/{hospitalId}")]
        public IHttpActionResult Get(int hospitalId)
        {
            var caller = User as ClaimsPrincipal;

            var subjectClaim = caller.FindFirst("sub");
            if (subjectClaim == null)
            {
                return Unauthorized();
            }

            var userId = subjectClaim.Value;

            var userAegisPermissions = Config.GetUserPermissionsFromCidm(clientName: "med_data_service", clientSecret: "C307B573-1B25-4DF5-8AC7-E7f25A43C229", userId: userId);

            var authorized = AuthorizeResourceAccess(hospitalId, userAegisPermissions);

            if (!authorized)
            {
                return Unauthorized();
            }

            // access med data

            return Ok("med data");
        }

        private static bool AuthorizeResourceAccess(int hospitalId, string userAegisPermissions)
        {
            return true;
        }
    }
}
