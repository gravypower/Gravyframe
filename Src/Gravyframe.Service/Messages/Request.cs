// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Request.cs" company="Gravypowered">
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
//   Defines the Request type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.Messages
{
    /// <summary>
    /// The request.
    /// </summary>
    public abstract class Request
    {
        /// <summary>
        /// Gets or sets the site id.
        /// </summary>
        /// <value>
        /// The site id.
        /// </value>
        public string SiteId { get; set; }
    }
}
