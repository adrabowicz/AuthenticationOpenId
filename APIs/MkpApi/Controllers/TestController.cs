using System.Security.Claims;
using System.Web.Http;

namespace MkpApi.Controllers
{
    public class TestController : ApiController
    {
        [Route("test")]
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            if (caller == null)
            {
                return Ok();
            }

            return Json(new
            {
                message = "OK computer",
                client = caller.FindFirst("client_id").Value
            });
        }
    }
}
