using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;
using Shared;

namespace CommonApi.Controllers
{
    [ScopeAuthorize("common_menu_api")]
    public class MenuController : BaseApiController
    {
        [Route("menu/{appId}")]
        public IHttpActionResult GetCommonMenu(string appId)
        {
            var userId = AuthorizeUser();
            if (userId == null)
            {
                return Unauthorized();
            }

            var aegisPermissions = GetAppDataFromCidm(clientName: "common_service", clientSecret: "E901482E-8284-4A6B-889C-F40978934C89", userId: userId);

            // retrieve menu data for application with id: appId

            return Ok("lists of menus, list of IDNs, list of hospitals");
        }
    }
}
