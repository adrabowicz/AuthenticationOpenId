﻿using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace CidmApi.Controllers
{
    [ScopeAuthorize("cidm_permissions.read")]
    public class PermissionsReadController : ApiController
    {
        [Route("permissions/{userId}")]
        public IHttpActionResult GetPermissions(string userId)
        {
            // get permissions from AEGIS database

            return Ok("AEGIS permissions");
        }
    }
}
