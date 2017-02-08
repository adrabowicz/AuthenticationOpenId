using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace MkpApi.Controllers
{
    [ScopeAuthorize("med_data.write")]
    public class MedWriteController : ApiController
    {
        [Route("inventory-data")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
