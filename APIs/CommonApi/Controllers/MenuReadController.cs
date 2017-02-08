using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CommonApi.Controllers
{
    [ScopeAuthorize("common_menu.read")]
    class MenuReadController : ApiController
    {
        [Route("menu")]
        public IHttpActionResult GetCommonMenu()
        {
            return Ok();
        }
    }
}
