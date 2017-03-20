using System;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;
using Configuration;
using IdentityModel.Client;

namespace CommonApi.Controllers
{
    [ScopeAuthorize("user_info")]
    public class UserInfoController : BaseApiController
    {
        [Route("user-info")]
        public IHttpActionResult GetUserInfo()
        {
            var userId = AuthorizeUser();
            if (userId == null)
            {
                return Unauthorized();
            }

            var aegisData = GetUserDataFromCidm(clientName: "med_data_service", clientSecret: "C307B573-1B25-4DF5-8AC7-E7f25A43C229", userId: userId);

            // retrieve user info 

            return Ok("user info");
        }
    }
}
