using System;
using System.Security.Claims;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace AMkpApipis
{
    [Route("test")]
    [ScopeAuthorize("med.read", "med.readwrite")]
    public class InfusionReadController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            var subjectClaim = caller.FindFirst("sub");
            if (subjectClaim != null)
            {
                return Json(new
                {
                    message = "OK user",
                    client = caller.FindFirst("client_id").Value,
                    subject = subjectClaim.Value
                });
            }
            else
            {
                throw new Exception("sub claim not found");
            }
        }
    }
}