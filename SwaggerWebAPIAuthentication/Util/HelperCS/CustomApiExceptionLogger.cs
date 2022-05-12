
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http.ExceptionHandling;

namespace SwaggerWebAPIAuthentication.Util.HelperCS
{
    public class CustomApiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var dict = new Dictionary<string, object>
                        {
                            {"RequestURI", context.Request.RequestUri},
                            {"CatchBlockName", context.CatchBlock.Name},
                            {"Principal Name", context.RequestContext.Principal.Identity.Name}
                        };

            var cp = context.RequestContext.Principal as ClaimsPrincipal;
            if (cp != null)
            {
                foreach (var claim in cp.Claims)
                {
                    dict.Add(claim.Type, claim.Value);
                }
            }

            var errorId = Guid.NewGuid().ToString();  // This is here because the Logger is called BEFORE the Handler in the Web API exception pipeline   
            context.Exception.Data.Add("ErrorId", errorId);

            //CustomLogger.WriteLog(context.Exception, CustomLoggingCategory.WebService, dict);
        }
    }
}