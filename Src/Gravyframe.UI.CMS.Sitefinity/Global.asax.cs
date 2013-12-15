// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Gravypowered">
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
//   Defines the Global type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.UI.CMS.Sitefinity
{
    using System;

    using Gravyframe.ServiceStack.Hosting;

    /// <summary>
    /// The global.
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// The application_ start.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The EventArgs.
        /// </param>
        protected void Application_Start(object sender, EventArgs e)
        {
            var automaticServiceHosting = new AutomaticServiceHosting<IAutomaticServiceHostingConfigurationStrategy>();
            automaticServiceHosting.Initialise();

            var gravyframeHost = new GravyframeHost(automaticServiceHosting.ConfigurationStrategies, "Gravyframe Services", automaticServiceHosting.ServiceAssembly);
            gravyframeHost.Init();
        }
    }
}