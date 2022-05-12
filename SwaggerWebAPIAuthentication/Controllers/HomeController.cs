using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SwaggerAuthenticationChecking.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwaggerWebAPIAuthentication.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationOAuthProvider applicationProvider { get; set; }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Login()
        {
            OAuthAuthorizationServerOptions _oContext = new OAuthAuthorizationServerOptions
            {
                AccessTokenExpireTimeSpan = new TimeSpan(00, 10, 00),
                AccessTokenProvider = new Microsoft.Owin.Security.Infrastructure.AuthenticationTokenProvider(),
                AllowInsecureHttp = true,
                ApplicationCanDisplayErrors = false,
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                AuthenticationType = "Bearer",
                AuthorizationCodeExpireTimeSpan = new TimeSpan(00, 05, 00),
                AuthorizeEndpointPath = new Microsoft.Owin.PathString("/api/Account/ExternalLogin"),
                Description = new Microsoft.Owin.Security.AuthenticationDescription(),
                FormPostEndpoint = new Microsoft.Owin.PathString(),
                RefreshTokenProvider = new Microsoft.Owin.Security.Infrastructure.AuthenticationTokenProvider(),
                SystemClock = new Microsoft.Owin.Infrastructure.SystemClock(),
                TokenEndpointPath = new Microsoft.Owin.PathString("/Token"),

            };
            
            Microsoft.Owin.IOwinContext _owinContext = new Microsoft.Owin.OwinContext();
            Microsoft.Owin.IReadableStringCollection rscContext = new Microsoft.Owin.ReadableStringCollection(new Dictionary<string,string[]>());
            
            var ovContext = new OAuthValidateClientAuthenticationContext(context: _owinContext, options: _oContext, parameters: rscContext);
            
            applicationProvider.ValidateClientAuthentication(ovContext);


            OAuthGrantResourceOwnerCredentialsContext _ogrocContext = new OAuthGrantResourceOwnerCredentialsContext(_owinContext, _oContext,"", "arminehbaronian@gmail.com", "123456", new List<string>());
            
            applicationProvider.GrantResourceOwnerCredentials(context: _ogrocContext);

            OAuthTokenEndpointContext _oteContext = new OAuthTokenEndpointContext(_owinContext, _oContext, ticket: _ogrocContext.Ticket, tokenEndpointRequest: new Microsoft.Owin.Security.OAuth.Messages.TokenEndpointRequest(rscContext));
            applicationProvider.TokenEndpoint(context: _oteContext);
           
            return View();
        }
    }
}
