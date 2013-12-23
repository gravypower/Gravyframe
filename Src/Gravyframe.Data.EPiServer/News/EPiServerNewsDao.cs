// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EpiServerNewsDao.cs" company="Gravypowered">
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
//   Defines the EpiServerNewsDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Data.EPiServer.News
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;

    using global::EPiServer;
    using global::EPiServer.Core;
    using global::EPiServer.Search;

    using Gravyframe.Data.News;
    using Gravyframe.Models.EPiServer;

    /// <summary>
    /// The EPiServer news dao.
    /// </summary>
    public class EPiServerNewsDao : NewsDao<EPiServerNews>
    {
         /// <summary>
        /// The body alias.
        /// </summary>
        public const string BodyAlias = "body";

        /// <summary>
        /// The title alias.
        /// </summary>
        public const string TitleAlias = "title";

        /// <summary>
        /// The categories alias.
        /// </summary>
        public const string CategoriesAlias = "categories";

        /// <summary>
        /// The name of the index Field for the site.
        /// </summary>
        public const string SiteIndexFieldName = "site";

        private readonly IContentRepository contentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EPiServerNewsDao"/> class.
        /// </summary>
        /// <param name="contentRepository">
        /// The content repository.
        /// </param>
        public EPiServerNewsDao(IContentRepository contentRepository)
        {
            this.contentRepository = contentRepository;
        }

        /// <summary>
        /// The get news.
        /// </summary>
        /// <param name="newsId">
        /// The news id.
        /// </param>
        /// <returns>
        /// The <see cref="EPiServerNews"/>.
        /// </returns>
        public override EPiServerNews GetNews(string newsId)
        {
            var content = this.contentRepository.Get<IContent>(Guid.Parse(newsId));

            if (content == null || content.ContentGuid == Guid.Empty)
            {
                return null;
            }

            var epiServerNews = new EPiServerNews
            {
                ContentGuid = content.ContentGuid
            };

            if (content.Property[BodyAlias] != null)
            {
                epiServerNews.Body = (string)content.Property[BodyAlias].Value;
            }

            if (content.Property[TitleAlias] != null)
            {
                epiServerNews.Title = (string)content.Property[TitleAlias].Value;
            }

            return epiServerNews;
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
        /// The <see cref="EPiServerNews"/>.
        /// </returns>
        public override EPiServerNews GetNews(string siteId, string newsId)
        {
            return this.GetNews(newsId);
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
        public override IEnumerable<EPiServerNews> GetNewsByCategoryId(string categoryId)
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
        public override IEnumerable<EPiServerNews> GetNewsByCategoryId(string categoryId, int listSize)
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
        /// The page number.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<EPiServerNews> GetNewsByCategoryId(string categoryId, int listSize, int pageNumber)
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
        public override IEnumerable<EPiServerNews> GetNewsByCategoryId(string siteId, string categoryId)
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
        public override IEnumerable<EPiServerNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize)
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
        public override IEnumerable<EPiServerNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize, int pageNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
