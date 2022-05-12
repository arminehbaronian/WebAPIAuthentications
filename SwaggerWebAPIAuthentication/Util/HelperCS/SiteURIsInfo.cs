using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwaggerWebAPIAuthentication.Util.HelperCS
{
   
    public class SiteURIsInfo
    {
        public static string MyEnvironment { get; set; }
        public static string GetIssuerUri()
        {
            switch (MyEnvironment)
            {
                case "PRD":
                    return "https://id.mydomain.com/identity";
                case "QA":
                    return "https://localhost:44389/identity";
                default:
                    return "https://id.local/identity";  // probably locally-hosted within IIS on developer machine
            }
        }

    }
}