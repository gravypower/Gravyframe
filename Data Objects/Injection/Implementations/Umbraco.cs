using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using DataObjects.EntityFramework;
using umbraco.NodeFactory;

namespace DataObjects.Injection.Implementations
{
    public class Umbraco
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
