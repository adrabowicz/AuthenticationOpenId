using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CommonApi.Controllers
{
    [Route("test")]
    [ScopeAuthorize("common_menu.read")]
    class MenuReadController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
