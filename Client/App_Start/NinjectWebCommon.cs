using System;
using System.Web;
using SitecoreClient.Repositories;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Service.ServiceContracts;
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

            //only bind up things here that are needed for this presentation implementation
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<IArticleRepository>().To<ArticleRepository>();

            //call the RegisterServices in the service layer 
            Service.Injection.Implementations.Sitecore.RegisterServices(kernel);
            
        }        
    }
}
