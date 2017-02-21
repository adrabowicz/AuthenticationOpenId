using System.Security.Claims;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;
using Configuration;

namespace CommonApi.Controllers
{
    [ScopeAuthorize("common_menu.read")]
    public class MenuReadController : ApiController
    {
        [Route("menu/{appId}")]
        public IHttpActionResult GetCommonMenu(string appId)
        {
            var caller = User as ClaimsPrincipal;

            var subjectClaim = caller.FindFirst("sub");
            if (subjectClaim == null)
            {
                return Unauthorized();
            }

            var userId = subjectClaim.Value;

            var userAegisPermissions = Config.GetUserPermissionsFromCidm(clientName: "med_data_service", clientSecret: "C307B573-1B25-4DF5-8AC7-E7f25A43C229", userId: userId);

            // retrieve menu data for appId

            return Ok("menus, IDNs, hospitals");
        }
    }
}
