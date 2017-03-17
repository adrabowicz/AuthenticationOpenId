using System.Net.Http;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;
using Configuration;

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
            var client = new HttpClient();
            client.SetBearerToken(ActionContext.Request.Headers.Authorization.Parameter);
            var userInfo = client.GetAsync(Config.IdentityServerUserInfoIP).Result;

            return Ok("user info");
        }
    }
}
