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

            var aegisData = GetUserDataFromCidm(clientName: "common_service", clientSecret: "E901482E-8284-4A6B-889C-F40978934C89", userId: userId);

            // retrieve user info 

            return Ok("user info");
        }
    }
}
