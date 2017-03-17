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

            // use the access token to retrieve claims from userinfo
            var accessToken = ActionContext.Request.Headers.Authorization.Parameter;
            var client = new UserInfoClient(new Uri(Config.IdentityServerUserInfoIP), accessToken);
            var userInfoResponse = client.GetAsync().Result;
            var claims = userInfoResponse.GetClaimsIdentity().Claims;

            return Ok("user info");
        }
    }
}
