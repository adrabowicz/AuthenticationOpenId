using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CommonApi.Controllers
{
    [ScopeAuthorize("common_menu.read")]
    class MenuReadController : ApiController
    {
        [Route("menu/{appId}")]
        public IHttpActionResult GetCommonMenu(string appId)
        {
            return Ok();
        }
    }
}
