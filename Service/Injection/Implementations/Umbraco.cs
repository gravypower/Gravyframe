using System;
using System.Linq;
using Glass.Sitecore.Mapper;
using Ninject;
using WebsiteKernel.Mapping;
using WebsiteKernel.Mapping.Implementations;
using Service.Mappers;
using DataObjects;
using DataObjects.Umbraco.Implementation;

namespace Service.Injection.Implementations
{
    public class Umbraco
    {
        /// <summary>
        /// do any ninject binding needed for the service tier or down so that we can swap 
        /// out presentation projects with out we writing load of binding code that will 
        /// be the same
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMapper>().To<AutoMapper>().InSingletonScope();
            kernel.Bind<IDataTransferObjectsMapper>().To<DataTransferObjectsMapper>().InSingletonScope();

            //call the injection in the data layer so i don't have to reference Umbraco at all in this lib :)
            kernel.Bind<ISitecoreContext>().To<SitecoreContext>();
            kernel.Bind<IMapper>().To<AutoMapper>().InSingletonScope();
            kernel.Bind<IDataTransferObjectsMapper>().To<DataTransferObjectsMapper>().InSingletonScope();

            kernel.Bind<ISiteConfigurationDao>().To<UmbracoSiteConfigurationDao>().InSingletonScope();
            kernel.Bind<IWebsiteContentDao>().To<UmbracoWebsiteContentDao>().InSingletonScope();
            kernel.Bind<IWebsiteEventDao>().To<UmbracoWebsiteEventDao>().InSingletonScope();
            kernel.Bind<IWebsiteNavigationDao>().To<UmbracoWebsiteNavigationDao>().InSingletonScope();
            kernel.Bind<IWebsiteNewsDao>().To<UmbracoWebsiteNewsDao>().InSingletonScope();
        }
    }
}
