using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SwaggerWebAPIAuthentication.Controllers
{
    [RoutePrefix("api/keennewstuff")]
    [Authorize]
    public class KeenNewApiController : ApiController
    {
        [Route("getstuff")]
        public string GetStuff()
        {
            return "Here is some stuff";
        }

        [OverrideAuthorization]
        [AllowAnonymous]
        [Route("getanonymous")]
        public string GetAnonymous()
        {
            return "yay!";
        }
    }

}