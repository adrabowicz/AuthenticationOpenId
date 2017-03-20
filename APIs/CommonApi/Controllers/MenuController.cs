using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;
using Configuration;

namespace CommonApi.Controllers
{
    [ScopeAuthorize("common_menu")]
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

            var aegisPermissions = GetAppDataFromCidm(clientName: "med_data_service", clientSecret: "C307B573-1B25-4DF5-8AC7-E7f25A43C229", userId: userId);

            // retrieve menu data for application with id: appId

            return Ok("lists of menus, list of IDNs, list of hospitals");
        }
    }
}
