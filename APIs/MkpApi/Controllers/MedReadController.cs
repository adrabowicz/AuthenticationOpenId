using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace MkpApi.Controllers
{
    [ScopeAuthorize("med_data.read")]
    public class MedReadController : ApiController
    {
        [Route("med-data")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
