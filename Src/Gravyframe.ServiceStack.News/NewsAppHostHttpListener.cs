// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsAppHostHttpListener.cs" company="Gravypowered">
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
//   Defines the NewsAppHostHttpListener type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.News
{
    using System.Reflection;

    using Funq;

    using global::ServiceStack.WebHost.Endpoints;

    /// <summary>
    /// The news app host http listener.
    /// </summary>
    public class NewsAppHostHttpListener : AppHostHttpListenerBase
    {
        private readonly NewsConfigurationStrategy configurationStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsAppHostHttpListener"/> class.
        /// </summary>
        /// <param name="configurationStrategy">
        /// The configuration strategy.
        /// </param>
        /// <param name="serviceName">
        /// The service name.
        /// </param>
        /// <param name="assembliesWithServices">
        /// The assemblies with services.
        /// </param>
        protected NewsAppHostHttpListener(News.NewsConfigurationStrategy configurationStrategy, string serviceName, params Assembly[] assembliesWithServices)
            : base(serviceName, assembliesWithServices)
        {
            this.configurationStrategy = configurationStrategy;
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public override void Configure(Container container)
        {
            this.configurationStrategy.ConfigureContainer(container);
            this.configurationStrategy.ConfigureRoutes(this.Routes);
        }
    }
}
