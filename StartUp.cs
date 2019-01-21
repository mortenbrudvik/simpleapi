using System.Net.Http.Formatting;
using System.Security.Permissions;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Newtonsoft.Json.Serialization;
using Owin;
using Unity;
using Unity.WebApi;
using WebApiServerConsole.Middleware;
using WebApiServerConsole.Services;

namespace WebApiServerConsole
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            // DI - Register services
            var container = new UnityContainer();
            var serviceFactory = new ServiceFactory();
            var loggerService = serviceFactory.CreateLogger();
            container.RegisterInstance(loggerService);
            config.DependencyResolver = new UnityDependencyResolver(container);
            
            // Cors
            var attr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(attr);

            // Enable Json formatting - CamelCase
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Routes setup
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("SimpleApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
            
            // Middleware
            app.Use<RequestLoggingMiddleware>(loggerService);
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler(loggerService)); // Catches unhandled exceptions.
            
            app.UseWebApi(config);
        }
    }
}