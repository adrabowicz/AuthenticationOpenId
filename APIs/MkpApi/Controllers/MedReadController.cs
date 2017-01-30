using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace MkpApi.Controllers
{
    [Route("test")]
    [ScopeAuthorize("med_data.read")]
    public class MedReadController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
