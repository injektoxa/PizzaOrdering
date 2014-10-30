using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Pizza.Model;

namespace Pizza.Presentation
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<PizzaContext>(null);
        }

        protected void Application_BeginRequest()
        {
            AppManager.CreateContext();
        }

        protected void Application_EndRequest()
        {
            AppManager.CloseContext();
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }
    }
}