using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace MkpApi.Controllers
{
  //  [ScopeAuthorize("med_data.write")]
    public class MedWriteController : ApiController
    {
        [Route("med-data-write")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
