using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace WebsiteKernel
{

    public class WebsiteKernalNinjectKernelContainer
    {
        /// <summary>
        /// The ninject kernel.
        /// </summary>
        private static IKernel kernel;

        /// <summary>
        /// Gets or sets the kernel that is used in the application.
        /// </summary>
        public static IKernel Kernel
        {
            get
            {
                return kernel;
            }

            set
            {
                if (kernel != null)
                {
                    throw new NotSupportedException("The static container already has a kernel associated with it!");
                }

                kernel = value;
            }
        }

        /// <summary>
        /// Injects the specified instance by using the container's kernel.
        /// </summary>
        /// <param name="instance">The instance to inject.</param>
        public static void Inject(object instance)
        {
            if (kernel == null)
            {
                throw new InvalidOperationException(
                    String.Format(
                                  "The type {0} requested an injection, but no kernel has been registered for the web application.\r\n" +
                                  "Please ensure that your project defines a NinjectHttpApplication.",
                        instance.GetType()));
            }

            kernel.Inject(instance);
        }
    }
}
