// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SitefinityNewsDao.cs" company="Gravypowered">
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
//   Defines the SitefinityNewsDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Data.Sitefinity.News
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Gravyframe.Data.News;
    using Gravyframe.Models.Sitefinity;

    using Telerik.Sitefinity.Modules.News;

    /// <summary>
    /// The sitefinity news dao.
    /// </summary>
    public class SitefinityNewsDao : NewsDao<SitefinityNews>
    {
        /// <summary>
        /// The news data provider.
        /// </summary>
        protected readonly NewsDataProvider NewsDataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SitefinityNewsDao"/> class.
        /// </summary>
        /// <param name="newsDataProvider">
        /// The news data provider.
        /// </param>
        public SitefinityNewsDao(NewsDataProvider newsDataProvider)
        {
            this.NewsDataProvider = newsDataProvider;
        }

        /// <summary>
        /// The get news.
        /// </summary>
        /// <param name="newsId">
        /// The news id.
        /// </param>
        /// <returns>
        /// The <see cref="SitefinityNews"/>.
        /// </returns>
        public override SitefinityNews GetNews(string newsId)
        {
            var news = (SitefinityNews)this.NewsDataProvider.GetNewsItem(Guid.Parse(newsId));
            return news;
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
        /// The <see cref="SitefinityNews"/>.
        /// </returns>
        public override SitefinityNews GetNews(string siteId, string newsId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The get news by category id.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<SitefinityNews> GetNewsByCategoryId(string categoryId)
        {
            throw new System.NotImplementedException();
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
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<SitefinityNews> GetNewsByCategoryId(string categoryId, int listSize)
        {
            throw new System.NotImplementedException();
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
        /// <param name="pageNumber">
        /// The pageNumber number.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<SitefinityNews> GetNewsByCategoryId(string categoryId, int listSize, int pageNumber)
        {
            throw new System.NotImplementedException();
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
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<SitefinityNews> GetNewsByCategoryId(string siteId, string categoryId)
        {
            throw new System.NotImplementedException();
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
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<SitefinityNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize)
        {
            throw new System.NotImplementedException();
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
        /// <param name="pageNumber">
        /// The page number.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<SitefinityNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize, int pageNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
