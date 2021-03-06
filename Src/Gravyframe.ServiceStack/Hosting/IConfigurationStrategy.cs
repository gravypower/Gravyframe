﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationStrategy.cs" company="Gravypowered">
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
//   The news app host configuration strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.Hosting
{
    using Funq;

    using global::ServiceStack.ServiceHost;

    /// <summary>
    /// The ConfigurationStrategy interface.
    /// </summary>
    public interface IConfigurationStrategy
    {
        /// <summary>
        /// The configure container.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        void ConfigureContainer(Container container);

        /// <summary>
        /// The configure routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        void ConfigureRoutes(IServiceRoutes routes);
    }
}
