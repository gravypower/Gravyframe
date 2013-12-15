// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsService.cs" company="Gravypowered">
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
//   Defines the NewsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.News
{
    using System;

    using Gravyframe.Models;

    /// <summary>
    /// The news service.
    /// </summary>
    /// <typeparam name="TNews">
    /// The type of News, must be of type Gravyframe.Models.News.
    /// </typeparam>
    public class NewsService<TNews> : Service<NewsRequest, NewsResponse<TNews>, NewsService<TNews>.NullNewsRequestException>
        where TNews : INews
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsService{TNews}"/> class.
        /// </summary>
        /// <param name="responseHydrogenationTasks">
        /// The response hydrogenation tasks.
        /// </param>
        public NewsService(IResponseHydrogenationTaskList<NewsRequest, NewsResponse<TNews>> responseHydrogenationTasks) : base(responseHydrogenationTasks)
        {
        }

        /// <summary>
        /// The null news request exception.
        /// </summary>
        [Serializable]
        public class NullNewsRequestException : NullRequestException
        {
        }
    }
}
