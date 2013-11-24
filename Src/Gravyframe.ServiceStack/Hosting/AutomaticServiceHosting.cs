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
    using System.Reflection.Emit;
    using System.Threading;

    using global::ServiceStack.ServiceHost;

    /// <summary>
    /// The automatic service hosting.
    /// </summary>
    /// <typeparam name="TConfigurationStrategy">
    /// The type to look for when automatically hosting, must be of type IConfigurationStrategy.
    /// </typeparam>
    public abstract class AutomaticServiceHosting<TConfigurationStrategy>
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
        protected AutomaticServiceHosting()
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
            var assemblyName = new AssemblyName { Name = DefaultAssemblyName };
            var assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyBuilder.GetName().Name, false);

            this.CreateTypes(moduleBuilder, assemblyName);

            this.ServiceAssembly = moduleBuilder.Assembly;
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

        private static void GuardType(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new NullServiceTypeException();
            }
        }

        private static void CreateType(ModuleBuilder moduleBuilder, AssemblyName assemblyName, Type serviceType)
        {
            moduleBuilder.DefineType(
                assemblyName + "." + serviceType.Name,
                GetTypeAttributes(),
                serviceType,
                new[] { typeof(IService) }).CreateType();
        }

        private static TypeAttributes GetTypeAttributes()
        {
            return TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout;
        }

        private void CreateTypes(ModuleBuilder moduleBuilder, AssemblyName assemblyName)
        {
            foreach (var configurationStrategy in this.ConfigurationStrategies)
            {
                var serviceType = configurationStrategy.GetServiceType();
                GuardType(serviceType);
                CreateType(moduleBuilder, assemblyName, serviceType);
            }
        }

        /// <summary>
        /// The null service type exception.
        /// </summary>
        public class NullServiceTypeException : Exception
        {
        }
    }
}
