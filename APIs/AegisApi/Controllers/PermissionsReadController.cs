using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CidmApi.Controllers
{
    [Route("test")]
    [ScopeAuthorize("cidm_permissions.read")]
    public class PermissionsReadController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
