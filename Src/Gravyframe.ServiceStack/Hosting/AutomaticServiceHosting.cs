// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutomaticServiceHosting.cs" company="Gravypowered">
//   Copyright 2013 Aaron Job
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Defines the AutomaticServiceHosting type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using global::ServiceStack.ServiceHost;

    using Gravyframe.Kernel.Reflection;

    /// <summary>
    /// The automatic service hosting.
    /// </summary>
    /// <typeparam name="TConfigurationStrategy">
    /// The type to look for when automatically hosting, must be of type IConfigurationStrategy.
    /// </typeparam>
    public class AutomaticServiceHosting<TConfigurationStrategy>
        where TConfigurationStrategy : IAutomaticServiceHostingConfigurationStrategy
    {
        /// <summary>
        /// The default assembly name.
        /// </summary>
        public const string DefaultAssemblyName = "Gravyframe.ServiceStack.DynamicServices";

        private readonly List<TConfigurationStrategy> configurationStrategies = new List<TConfigurationStrategy>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomaticServiceHosting{TConfigurationStrategy}"/> class. 
        /// </summary>
        public AutomaticServiceHosting()
        {
            foreach (var serviceHostingConfigurationStrategy in GetServiceHostingConfigurationStrategies())
            {
                this.configurationStrategies.Add((TConfigurationStrategy)Activator.CreateInstance(serviceHostingConfigurationStrategy));
            }
        }

        /// <summary>
        /// Gets the configuration strategies.
        /// </summary>
        /// <value>
        /// The configuration strategies.
        /// </value>
        public IEnumerable<TConfigurationStrategy> ConfigurationStrategies
        {
            get
            {
                return this.configurationStrategies;
            }
        }

        /// <summary>
        /// Gets the service assemblies.
        /// </summary>
        /// <value>
        /// The service assemblies.
        /// </value>
        public Assembly ServiceAssembly { get; private set; }

        /// <summary>
        /// The Initialise.
        /// </summary>
        public void Initialise()
        {
            var typeBuilder = new FluentTypeBuilder(AppDomain.CurrentDomain)
                .SetAssemblyName(DefaultAssemblyName)
                .Implementes<IService>();

            foreach (var configurationStrategy in this.ConfigurationStrategies)
            {
                var serviceType = configurationStrategy.GetServiceType();
                if (serviceType == null)
                {
                    throw new NullServiceTypeException();
                }

                typeBuilder
                    .SetTypeName(DefaultAssemblyName + "." + serviceType.Name)
                    .BaseTypeOf(serviceType)
                    .CreateType();
            }

            this.ServiceAssembly = typeBuilder.ModuleBuilder.Assembly;
        }

        private static IEnumerable<Type> GetServiceHostingConfigurationStrategies()
        {
            return GetLoadedAssemblies().SelectMany(s => s.GetTypes()).Where(CheckTypeIsAssignableToTConfigurationStrategy);
        }

        private static IEnumerable<Assembly> GetLoadedAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        private static bool CheckTypeIsAssignableToTConfigurationStrategy(Type t)
        {
            return typeof(TConfigurationStrategy).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsInterface;
        }

        /// <summary>
        /// The null service type exception.
        /// </summary>
        public class NullServiceTypeException : Exception
        {
        }
    }
}
