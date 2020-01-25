using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUD_WEBFORM.Startup))]
namespace CRUD_WEBFORM
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
