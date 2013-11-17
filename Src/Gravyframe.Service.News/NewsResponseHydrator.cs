// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsResponseHydrator.cs" company="Gravypowered">
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
//   Defines the NewsResponseHydrator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.News
{
    using Gravyframe.Configuration;
    using Gravyframe.Data.News;

    /// <summary>
    /// The news response hydrator.
    /// </summary>
    /// <typeparam name="TNews">
    /// the t
    /// </typeparam>
    public abstract class NewsResponseHydrator<TNews> : ResponseHydrator<NewsRequest, NewsResponse<TNews>>
        where TNews : Models.News
    {
        /// <summary>
        /// The news configuration.
        /// </summary>
        protected readonly INewsConfiguration NewsConfiguration;

        /// <summary>
        /// The news dao.
        /// </summary>
        protected readonly NewsDao<TNews> NewsDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsResponseHydrator{TNews}"/> class.
        /// </summary>
        /// <param name="newsDao">
        /// The news dao.
        /// </param>
        /// <param name="newsConfiguration">
        /// The news configuration.
        /// </param>
        protected NewsResponseHydrator(NewsDao<TNews> newsDao, INewsConfiguration newsConfiguration)
        {
            this.NewsConfiguration = newsConfiguration;
            this.NewsDao = newsDao;
        }
    }
}
