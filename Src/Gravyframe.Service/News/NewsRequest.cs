﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsRequest.cs" company="Gravypowered">
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
//   Defines the NewsRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.News
{
    using Gravyframe.Service.Messages;

    /// <summary>
    /// The news request.
    /// </summary>
    public class NewsRequest : Request
    {
        /// <summary>
        /// Gets or sets the news id.
        /// </summary>
        public string NewsId { get; set; }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public string CategoryId { get; set; }
    }
}
