using System.Security.Claims;
using System.Web.Http;

namespace Configuration
{
    public class BaseApiController : ApiController
    {
        protected string AuthorizeUser()
        {
            var caller = User as ClaimsPrincipal;
            return caller.FindFirst("sub")?.Value;
         }
    }
}
