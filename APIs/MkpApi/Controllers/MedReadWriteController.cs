using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace MkpApi.Controllers
{
    [Route("test")]
    [ScopeAuthorize("infusion.read")]
    public class MedReadWriteController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
