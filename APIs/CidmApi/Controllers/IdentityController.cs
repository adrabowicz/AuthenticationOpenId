using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CidmApi.Controllers
{
    [ScopeAuthorize("cidm_identity")]
    public class IdentityController : ApiController
    {
        [Route("identity/{userId}")]
        public IHttpActionResult GetUserData()
        {
            // get user data from AEGIS database

            return Ok("AEGIS user data");
        }
    }
}
