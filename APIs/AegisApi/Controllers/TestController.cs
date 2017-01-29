using System.Web.Http;

namespace CidmApi.Controllers
{
    [Route("test")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
