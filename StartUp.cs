using System.Web.Http;
using Owin;

namespace ConsoleApp4
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SimpleApi",
                routeTemplate: "simpleapi/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
            app.UseWebApi(config);
        }
    }
}