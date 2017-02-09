using System;
using System.Security.Claims;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace MkpApi.Controllers
{
  //  [ScopeAuthorize("infusion_data.read")]
    public class InfusionReadController : ApiController
    {
        [Route("infusion-data-read")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}