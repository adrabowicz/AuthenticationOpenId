using System.Security.Claims;
using System.Web.Http;

namespace CommonApi.Controllers
{
    public class TestController : ApiController
    {
        [Route("test")]
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            var clientId = caller.FindFirst("client_id");

            return Json(new
            {
                message = "OK computer",
                client = clientId == null ? "undefined" : caller.FindFirst("client_id").Value
            });
        }
    }
}
