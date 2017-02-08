using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CidmApi.Controllers
{
    [Route("test")]
    [ScopeAuthorize("cidm_identity.read")]
    public class IdentityReadController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
