using System;
using System.Linq;
using Glass.Sitecore.Mapper;
using Ninject;
using WebsiteKernel.Mapping;
using WebsiteKernel.Mapping.Implementations;
using Service.Mappers;


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
            kernel.Bind<ISitecoreContext>().To<SitecoreContext>();
            kernel.Bind<IMapper>().To<AutoMapper>().InSingletonScope();
            kernel.Bind<IDataTransferObjectsMapper>().To<DataTransferObjectsMapper>().InSingletonScope();

            //call the injection in the data layer so i don't have to reference Sitecore at all in this lib :)
            DataObjects.Injection.Implementations.Umbraco.RegisterServices(kernel);
        }
    }
}
