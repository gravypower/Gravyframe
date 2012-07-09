[assembly: WebActivator.PreApplicationStartMethod(typeof(SitecoreClient.App_Start.NinjectWeb), "Start")]

namespace SitecoreClient.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject.Web.Sitecore;

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
