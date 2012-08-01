using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Service.ServiceContracts;
using WebsiteKernel.Logging;
using WebsiteKernel.Logging.Sitrecore;
using WebsiteControls;
using SitecoreClient.WebsiteControls;
using WebsiteControls.News;
using WebsiteControls.Gateways.SiteConfiguration;
using WebsiteControls.Gateways.WebsiteContent;
using WebsiteControls.Gateways.WebsiteEvent;
using WebsiteControls.Gateways.WebsiteNavigation;
using WebsiteControls.Gateways.WebsiteNews;
using Service.ServiceImplementations;

//	Assembly and module attributes must precede all other elements defined in a file except using clauses and extern alias declarations
[assembly: WebActivator.PreApplicationStartMethod(typeof(SitecoreClient.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(SitecoreClient.App_Start.NinjectWebCommon), "Stop")]

namespace SitecoreClient.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<Logger>().To<SitrecoreLogging>();

            kernel.Bind<IItemIDService>().To<ItemIDService>();
            kernel.Bind<IClientTagService>().To<ClientTagService>();

            kernel.Bind<ISiteConfigurationGateway>().To<SiteConfigurationGateway>();
            kernel.Bind<IWebsiteContentGateway>().To<WebsiteContentGateway>();
            kernel.Bind<IWebsiteEventGateway>().To<WebsiteEventGateway>();
            kernel.Bind<IWebsitelNavigationGateway>().To<WebsitelNavigationGateway>();
            kernel.Bind<IWebsiteNewsGateway>().To<WebsiteNewsGateway>();

            kernel.Bind<ISiteConfigurationService>().To<SiteConfigurationService>();
            kernel.Bind<IWebsiteContentService>().To<WebsiteContentService>();
            kernel.Bind<IWebsiteEventService>().To<WebsiteEventService>();
            kernel.Bind<IWebsiteNavigationService>().To<WebsiteNavigationService>();
            kernel.Bind<IWebsiteNewsService>().To<WebsiteNewsService>();


            //call the RegisterServices in the service layer 
            Service.Injection.Implementations.Sitecore.RegisterServices(kernel);
            
        }        
    }
}
