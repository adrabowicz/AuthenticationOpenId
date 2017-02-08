using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CidmApi.Controllers
{
    [ScopeAuthorize("cidm_permissions.read")]
    public class PermissionsReadController : ApiController
    {
        [Route("permissions")]
        public IHttpActionResult GetPermissions()
        {
            return Ok();
        }
    }
}
