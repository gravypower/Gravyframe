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
    using global::Umbraco.Core;

    using Gravyframe.ServiceStack.Hosting;

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
            var automaticServiceHosting = new AutomaticServiceHosting<IAutomaticServiceHostingConfigurationStrategy>();
            automaticServiceHosting.Initialise();

            var gravyframeHost = new GravyframeHost(automaticServiceHosting.ConfigurationStrategies, "Gravyframe Services", automaticServiceHosting.ServiceAssembly);
            gravyframeHost.Init();
        }
    }
}