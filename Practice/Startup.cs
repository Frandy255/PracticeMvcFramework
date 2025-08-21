using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(Practice.Startup))]
namespace Practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}