using System.Web.Http;
using System.Web.Http.Cors;
using Owin;

namespace ConsoleApp4
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            var attr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(attr);

            config.Routes.MapHttpRoute("SimpleApi", "simpleapi/{controller}/{id}", new {id = RouteParameter.Optional});
            app.UseWebApi(config);
        }
    }
}