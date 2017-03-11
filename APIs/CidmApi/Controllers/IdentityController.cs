using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CidmApi.Controllers
{
    [ScopeAuthorize("cidm_identity")]
    public class IdentityController : ApiController
    {
        [Route("identity")]
        public IHttpActionResult GetUserInfo()
        {
            return Ok();
        }
    }
}
