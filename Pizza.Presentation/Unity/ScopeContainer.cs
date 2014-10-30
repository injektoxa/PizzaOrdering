//using System;
//using System.Collections.Generic;
//using System.Web.Http.Dependencies;
//using Microsoft.Practices.Unity;

//namespace Pizza.Presentation.Unity
//{
//    // This code is from:
//    // http://www.asp.net/web-api/overview/extensibility/using-the-web-api-dependency-resolver
//    // The website also has a detailed explanation of how to setup dependency injection

//    public class ScopeContainer : IDependencyScope
//    {
//        protected IUnityContainer Container;

//        public ScopeContainer(IUnityContainer container)
//        {
//            if (container == null)
//            {
//                throw new ArgumentNullException("container");
//            }
//            Container = container;
//        }

//        public object GetService(Type serviceType)
//        {
//            return Container.IsRegistered(serviceType) ? Container.Resolve(serviceType) : null;
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            return Container.IsRegistered(serviceType) ? Container.ResolveAll(serviceType) : new List<object>();
//        }

//        public void Dispose()
//        {
//            Container.Dispose();
//        }
//    }
//}