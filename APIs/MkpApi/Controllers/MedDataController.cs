﻿using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;
using Shared;

namespace MkpApi.Controllers
{
    [ScopeAuthorize("med_data_api")]
    public class MedDataController : BaseApiController
    {
        [Route("med-data/{hospitalId}")]
        public IHttpActionResult Get(int hospitalId)
        {
            var userId = AuthorizeUser();
            if (userId == null)
            {
                return Unauthorized();
            }

            var aegisPermissions = GetAppDataFromCidm(clientName: "med_data_service", clientSecret: "C307B573-1B25-4DF5-8AC7-E7f25A43C229", userId: userId);

            var authorized = AuthorizeResourceAccess(hospitalId, aegisPermissions);

            if (!authorized)
            {
                return Unauthorized();
            }

            // access med data

            return Ok("med data");
        }

        private static bool AuthorizeResourceAccess(int hospitalId, string userAegisPermissions)
        {
            return true;
        }
    }
}
