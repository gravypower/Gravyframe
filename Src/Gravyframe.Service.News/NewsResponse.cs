﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsResponse.cs" company="Gravypowered">
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
//   Defines the NewsResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.News
{
    using System.Collections.Generic;

    using Gravyframe.Models;
    using Gravyframe.Service.Messages;

    /// <summary>
    /// The news response.
    /// </summary>
    /// <typeparam name="TNews">
    /// The type of the news, must be of type Gravyframe.Models.News.
    /// </typeparam>
    public class NewsResponse<TNews> : Response
        where TNews : INews
    {
        /// <summary>
        /// Gets or sets the news.
        /// </summary>
        /// <value>
        /// The news object.
        /// </value>
        public TNews News { get; set; }

        /// <summary>
        /// Gets or sets the news list.
        /// </summary>
        /// <value>
        /// The news list.
        /// </value>
        public IEnumerable<TNews> NewsList { get; set; }
    }
}
