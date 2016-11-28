using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesWithAuth.Startup))]
namespace MoviesWithAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
