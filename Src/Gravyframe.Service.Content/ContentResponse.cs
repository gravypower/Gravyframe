// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentResponse.cs" company="Gravypowered">
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
//   Defines the ContentResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.Content
{
    using System.Collections.Generic;

    using Gravyframe.Service.Messages;

    /// <summary>
    /// The content response.
    /// </summary>
    public class ContentResponse : Response
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public Models.Content Content { get; set; }

        /// <summary>
        /// Gets or sets the content list.
        /// </summary>
        public IEnumerable<Models.Content> ContentList { get; set; }
    }
}
