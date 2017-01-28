using System;
using System.Security.Claims;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CommonApi.Controllers
{
    [Route("test")]
    [ScopeAuthorize("med.read", "med.readwrite")]
    class MenuReadController : ApiController
    {
        
    }
}
