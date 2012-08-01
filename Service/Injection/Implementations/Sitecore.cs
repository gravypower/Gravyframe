using System;
using System.Linq;
using Glass.Sitecore.Mapper;
using Ninject;
using WebsiteKernel.Mapping;
using WebsiteKernel.Mapping.Implementations;
using Service.Mappers;
using DataObjects;
using DataObjects.Sitecore.Implementation;

namespace Service.Injection.Implementations
{
    public class Sitecore
    {
        /// <summary>
        /// do any ninject binding needed for the service tier or down so that we can swap 
        /// out presentation projects with out we writing load of binding code that will 
        /// be the same
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISitecoreContext>().To<SitecoreContext>();
            kernel.Bind<IMapper>().To<AutoMapper>().InSingletonScope();
            kernel.Bind<IDataTransferObjectsMapper>().To<DataTransferObjectsMapper>().InSingletonScope();

            kernel.Bind<ISiteConfigurationDao>().To<SitecoreSiteConfigurationDao>().InSingletonScope();
            kernel.Bind<IWebsiteContentDao>().To<SitecoreWebsiteContentDao>().InSingletonScope();
            kernel.Bind<IWebsiteEventDao>().To<SitecoreIWebsiteEventDao>().InSingletonScope();
            //IWebsiteNavigationDao.cs
            kernel.Bind<IWebsiteNewsDao>().To<SitecoreWebsiteNewsDao>().InSingletonScope();
        }  
    }
}
