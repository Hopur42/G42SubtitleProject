using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(H42Skjatextar.Startup))]
namespace H42Skjatextar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
