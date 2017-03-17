using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

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

            return Ok("user info");
        }
    }
}
