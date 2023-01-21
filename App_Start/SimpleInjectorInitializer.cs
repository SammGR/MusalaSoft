[assembly: WebActivator.PostApplicationStartMethod(typeof(Gateways.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Gateways.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Gateways.Models;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // For instance:
            container.Register<IDeviceStorage, DeviceStorage>(Lifestyle.Scoped);
            container.Register<IGatewayStorage, GatewayStorage>(Lifestyle.Scoped);
        }
    }
}