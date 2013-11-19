// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GravyframeApplicationEventHandler.cs" company="Gravypowered">
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
//   Defines the GravyframeApplicationEventHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.Umbraco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading;

    using global::ServiceStack.ServiceHost;

    using global::Umbraco.Core;

    /// <summary>
    /// The gravyframe application event handler.
    /// </summary>
    public class GravyframeApplicationEventHandler : ApplicationEventHandler
    {
        /// <summary>
        /// The application started.
        /// </summary>
        /// <param name="umbracoApplication">
        /// The umbraco application.
        /// </param>
        /// <param name="applicationContext">
        /// The application context.
        /// </param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => typeof(IConfigurationStrategy).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsInterface);

            var assemblyName = new AssemblyName { Name = "Gravyframe.ServiceStack.Umbraco.Service" };
            var thisDomain = Thread.GetDomain();
            var asmBuilder = thisDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            var modBuilder = asmBuilder.DefineDynamicModule(asmBuilder.GetName().Name, false);

            var serviceTypes = new List<Assembly>();
            var configurationStrategies = new List<IConfigurationStrategy>();
            foreach (var type in types)
            {
                var configurationStrategy = (IConfigurationStrategy)Activator.CreateInstance(type);
                var serviceType = configurationStrategy.GetServiceType();

                var typeBuilder = modBuilder.DefineType(
                    "ServiceStack" + serviceType.Name,
                    GetTypeAttributes(),
                    serviceType,
                new[] { typeof(IService) });

                TypeBuilderHelper.CreatePassThroughConstructors(typeBuilder, serviceType);

                serviceTypes.Add(typeBuilder.CreateType().Assembly);
                configurationStrategies.Add(configurationStrategy);
            }

            new AppHost(configurationStrategies, "Gravyframe Services", serviceTypes.ToArray()).Init();
        }

        private static TypeAttributes GetTypeAttributes()
        {
            return TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass
                   | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout;
        }
    }
}