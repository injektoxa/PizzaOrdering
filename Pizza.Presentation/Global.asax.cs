using System.Configuration;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Pizza.DataAccess;
using Pizza.Model;
using Pizza.Model.Interfaces;
using Pizza.Presentation.Controllers;
using Unity.Mvc4;

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

            CreateUnityContainer();
        }

        private void CreateUnityContainer()
        {
            // Create a new Unity dependency injection container
            var unity = new UnityContainer();
            unity.RegisterType<IRepository<Category>, SqlRepository<Category>>();

            // Register the Controllers that should be injectable
            unity.RegisterType<CategoriesController>();

            // Finally, override the default dependency resolver with Unity
            DependencyResolver.SetResolver(new UnityDependencyResolver(unity));
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