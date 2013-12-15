// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopulateNewsByIdResponseHydrator.cs" company="Gravypowered">
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
//   Defines the PopulateNewsByIdResponseHydrator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.News.Tasks
{
    using System.Collections.Generic;

    using Gravyframe.Configuration;
    using Gravyframe.Data.News;
    using Gravyframe.Models;
    using Gravyframe.Service.Messages;

    /// <summary>
    /// The populate news by id response hydrator.
    /// </summary>
    /// <typeparam name="TNews">
    /// The type of News, must be of type Gravyframe.Models.News.
    /// </typeparam>
    public class PopulateNewsByIdResponseHydrator<TNews> : NewsResponseHydrator<TNews>
        where TNews : INews
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PopulateNewsByIdResponseHydrator{TNews}"/> class.
        /// </summary>
        /// <param name="newsDao">
        /// The news dao.
        /// </param>
        /// <param name="newsConfiguration">
        /// The news configuration.
        /// </param>
        public PopulateNewsByIdResponseHydrator(NewsDao<TNews> newsDao, INewsConfiguration newsConfiguration)
            : base(newsDao, newsConfiguration)
        {
        }

        /// <summary>
        /// The populate response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="response">
        /// The response.
        /// </param>
        public override void PopulateResponse(NewsRequest request, NewsResponse<TNews> response)
        {
            var news = string.IsNullOrEmpty(request.SiteId)
                ? NewsDao.GetNews(request.NewsId)
                : NewsDao.GetNews(request.SiteId, request.NewsId);

            if (news == null && news.Equals(default(TNews)))
            {
                response.Code = ResponseCodes.Failure;
            }
            else
            {
                response.News = news;
            }
        }

        /// <summary>
        /// The validate response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public override IEnumerable<string> ValidateResponse(NewsRequest request)
        {
            if (string.IsNullOrEmpty(request.NewsId))
            {
                return new List<string> { NewsConfiguration.NewsIdError };
            }

            return new List<string>();
        }
    }
}
