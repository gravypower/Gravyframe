// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EndPointConfiguration.cs" company="Gravypowered">
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
//   Defines the EndPointConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack
{
    /// <summary>
    /// The end point configuration.
    /// </summary>
    public class EndPointConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndPointConfiguration"/> class.
        /// </summary>
        public EndPointConfiguration()
        {
            this.AutomaticServiceWiringEnabled = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether automatic service wiring enabled.
        /// </summary>
        /// <value>
        /// The automatic service wiring enabled.
        /// </value>
        public bool AutomaticServiceWiringEnabled { get; set; }
    }
}
