// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryNewsDao.cs" company="Gravypowered">
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
//   Defines the InMemoryNewsDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Data.InMemory.News
{
    using System.Collections.Generic;
    using System.Linq;

    using Gravyframe.Configuration;
    using Gravyframe.Data.News;

    /// <summary>
    /// The in memory news dao.
    /// </summary>
    public class InMemoryNewsDao : NewsDao<Models.News>
    {
        private readonly List<Models.News> newsList;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryNewsDao"/> class.
        /// </summary>
        /// <param name="newsConfiguration">
        /// The news configuration.
        /// </param>
        public InMemoryNewsDao(INewsConfiguration newsConfiguration) : base(newsConfiguration)
        {
            this.newsList = new List<Models.News>();

            for (var i = 1; i < 100; i++)
            {
                this.newsList.Add(new Models.News { Sequence = i, Title = "Test" + i, Body = "Test" + i });
            }
        }

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
        /// The <see cref="News"/>.
        /// </returns>
        public override Models.News GetNews(string siteId, string newsId)
        {
            return this.GetNews(newsId);
        }

        /// <summary>
        /// The get news.
        /// </summary>
        /// <param name="newsId">
        /// The news id.
        /// </param>
        /// <returns>
        /// The <see cref="News"/>.
        /// </returns>
        public override Models.News GetNews(string newsId)
        {
            return new Models.News();
        }

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
        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId)
        {
            return this.newsList.Take(NewsConfiguration.DefaultListSize);
        }

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
        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize)
        {
            return this.newsList.Take(listSize);
        }

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
        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize, int page)
        {
            var pagesToSkip = CalculateNumberToSkip(listSize, page);
            return this.newsList.Skip(pagesToSkip).Take(listSize);
        }

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
        public override IEnumerable<Models.News> GetNewsByCategoryId(string siteId, string categoryId)
        {
            return this.GetNewsByCategoryId(categoryId);
        }

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
        public override IEnumerable<Models.News> GetNewsByCategoryId(string siteId, string categoryId, int listSize)
        {
            return this.GetNewsByCategoryId(categoryId, listSize);
        }

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
        public override IEnumerable<Models.News> GetNewsByCategoryId(string siteId, string categoryId, int listSize, int page)
        {
            return this.GetNewsByCategoryId(categoryId, listSize, page);
        }
    }
}
