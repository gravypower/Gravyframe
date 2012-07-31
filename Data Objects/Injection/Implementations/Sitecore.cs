using System;
using System.Linq;
using Ninject;
using Sitecore.Data.Items;
using DataObjects.Sitecore.Implementation;
using DataObjects.EntityFramework;

namespace DataObjects.Injection.Implementations
{
    public class Sitecore
    {
        /// <summary>
        /// Doing injection here so that i don't need a reference to sitecore anywhere else
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {

        }
    }
}
