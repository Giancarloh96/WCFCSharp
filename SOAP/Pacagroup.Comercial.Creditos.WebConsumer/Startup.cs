using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pacagroup.Comercial.Creditos.WebConsumer.Startup))]
namespace Pacagroup.Comercial.Creditos.WebConsumer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
