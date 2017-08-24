using System.Web.Http;

namespace TestApi
{
    public class TestController : ApiController
    {
        [Route("test")]
        public IHttpActionResult Get()
        {
            return Json(new
            {
                message = "OK computer"
            });
        }
    }
}