// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GravyframeHost.cs" company="Gravypowered">
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
//   Defines the GravyframeHost type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.Hosting
{
    using System.Collections.Generic;
    using System.Reflection;

    using Funq;

    using global::ServiceStack.WebHost.Endpoints;

    /// <summary>
    /// The gravyframe host.
    /// </summary>
    public class GravyframeHost : AppHostBase
    {
        private readonly IEnumerable<IConfigurationStrategy> configurationStrategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="GravyframeHost"/> class.
        /// </summary>
        /// <param name="configurationStrategies">
        /// The configuration strategies.
        /// </param>
        /// <param name="serviceName">
        /// The service name.
        /// </param>
        /// <param name="assembliesWithServices">
        /// The assemblies with services.
        /// </param>
        public GravyframeHost(IEnumerable<IConfigurationStrategy> configurationStrategies, string serviceName, params Assembly[] assembliesWithServices)
            : base(serviceName, assembliesWithServices)
        {
            this.configurationStrategies = configurationStrategies;
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public override void Configure(Container container)
        {
            foreach (var configurationStrategy in this.configurationStrategies)
            {
                configurationStrategy.ConfigureContainer(container);
                configurationStrategy.ConfigureRoutes(this.Routes);
            }
        }
    }
}
