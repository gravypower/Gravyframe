// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsDao.cs" company="Gravypowered">
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
//   Defines the NewsDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Data.News
{
    using System.Collections.Generic;

    using Gravyframe.Configuration;

    /// <summary>
    /// The news dao.
    /// </summary>
    /// <typeparam name="TNews">
    /// The type of News, must be of type Gravyframe.Models.News
    /// </typeparam>
    public abstract class NewsDao<TNews> where TNews : Models.News
    {
        /// <summary>
        /// The news configuration.
        /// </summary>
        public readonly INewsConfiguration NewsConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsDao{TNews}"/> class.
        /// </summary>
        protected NewsDao()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsDao{TNews}"/> class.
        /// </summary>
        /// <param name="newsConfiguration">
        /// The news configuration.
        /// </param>
        protected NewsDao(INewsConfiguration newsConfiguration)
        {
            this.NewsConfiguration = newsConfiguration;
        }

        /// <summary>
        /// The get news.
        /// </summary>
        /// <param name="newsId">
        /// The news id.
        /// </param>
        /// <returns>
        /// The <see cref="TNews"/>.
        /// </returns>
        public abstract TNews GetNews(string newsId);

        /// <summary>
        /// The get news.
        /// </summary>
        /// <param name="siteId">
        /// The site id.
        /// </param>
        /// <param name="newsId">
        /// The news id.
        /// </param>
        /// <returns>
        /// The <see cref="TNews"/>.
        /// </returns>
        public abstract TNews GetNews(string siteId, string newsId);

        /// <summary>
        /// The get news by category id.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId);

        /// <summary>
        /// The get news by category id.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="listSize">
        /// The list size.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId, int listSize);

        /// <summary>
        /// The get news by category id.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="listSize">
        /// The list size.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId, int listSize, int page);

        /// <summary>
        /// The get news by category id.
        /// </summary>
        /// <param name="siteId">
        /// The site id.
        /// </param>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public abstract IEnumerable<TNews> GetNewsByCategoryId(string siteId, string categoryId);

        /// <summary>
        /// The get news by category id.
        /// </summary>
        /// <param name="siteId">
        /// The site id.
        /// </param>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="listSize">
        /// The list size.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public abstract IEnumerable<TNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize);

        /// <summary>
        /// The get news by category id.
        /// </summary>
        /// <param name="siteId">
        /// The site id.
        /// </param>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="listSize">
        /// The list size.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public abstract IEnumerable<TNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize, int page);

        /// <summary>
        /// The calculate number to skip.
        /// </summary>
        /// <param name="listSize">
        /// The list size.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected static int CalculateNumberToSkip(int listSize, int page)
        {
            return (page - 1) * listSize;
        }
    }
}
