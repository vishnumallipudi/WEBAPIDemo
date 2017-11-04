using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeClient.Startup))]
namespace EmployeeClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
