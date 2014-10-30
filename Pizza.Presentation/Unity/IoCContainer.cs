//using System.Web.Http.Dependencies;
//using Microsoft.Practices.Unity;

//namespace Pizza.Presentation.Unity
//{
//    class IoCContainer : ScopeContainer, IDependencyResolver
//    {
//        public IoCContainer(IUnityContainer container)
//            : base(container)
//        {
//        }

//        public IDependencyScope BeginScope()
//        {
//            var child = Container.CreateChildContainer();
//            return new ScopeContainer(child);
//        }
//    }
//}