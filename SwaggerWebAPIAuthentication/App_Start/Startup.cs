

using IdentityServer3.AccessTokenValidation;
using Owin;
using SwaggerWebAPIAuthentication.Util.HelperCS;

namespace SwaggerWebAPIAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {

            var identity = new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = SiteURIsInfo.GetIssuerUri(),
                RequiredScopes = new string[] { "sampleapi" }
            };
            app.UseIdentityServerBearerTokenAuthentication(identity);
        }
    }
}