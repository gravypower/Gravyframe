// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmbracoNewsDao.cs" company="Gravypowered">
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
//   The umbraco news dao.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Data.Umbraco.News
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Examine;

    using Gravyframe.Configuration;
    using Gravyframe.Data.News;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Models.Umbraco;

    /// <summary>
    /// The umbraco news dao.
    /// </summary>
    public class UmbracoNewsDao : NewsDao<UmbracoNews>
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

        /// <summary>
        /// The searcher.
        /// </summary>
        protected readonly ISearcher Searcher;

        /// <summary>
        /// The node factory facade.
        /// </summary>
        protected readonly INodeFactoryFacade NodeFactoryFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoNewsDao"/> class.
        /// </summary>
        /// <param name="newsConfiguration">
        /// The news configuration.
        /// </param>
        /// <param name="nodeFactoryFacade">
        /// The node factory facade.
        /// </param>
        /// <param name="searcher">
        /// The searcher.
        /// </param>
        public UmbracoNewsDao(INewsConfiguration newsConfiguration, INodeFactoryFacade nodeFactoryFacade, ISearcher searcher)
            : base(newsConfiguration)
        {
            this.Searcher = searcher;
            this.NodeFactoryFacade = nodeFactoryFacade;
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
        /// The <see cref="UmbracoNews"/>.
        /// </returns>
        public override UmbracoNews GetNews(string siteId, string newsId)
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
        /// The <see cref="UmbracoNews"/>.
        /// </returns>
        public override UmbracoNews GetNews(string newsId)
        {
            var node = this.NodeFactoryFacade.GetNode(int.Parse(newsId));

            if (node == null || node.Id == 0)
            {
                return null;
            }

            var umbracoNews = new UmbracoNews
            {
                Id = node.Id
            };

            if (node.GetProperty(BodyAlias) != null)
            {
                umbracoNews.Body = node.GetProperty(BodyAlias).Value;
            }

            if (node.GetProperty(TitleAlias) != null)
            {
                umbracoNews.Title = node.GetProperty(TitleAlias).Value;
            }

            return umbracoNews;
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
        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string categoryId)
        {
            return this.GetAllNewsByCategoryId(categoryId).Take(NewsConfiguration.DefaultListSize);
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
        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string categoryId, int listSize)
        {
            return this.GetAllNewsByCategoryId(categoryId).Take(listSize);
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
        /// The pageNumber.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string categoryId, int listSize, int pageNumber)
        {
            var pagesToSkip = CalculateNumberToSkip(listSize, pageNumber);
            return this.GetAllNewsByCategoryId(categoryId).Skip(pagesToSkip).Take(listSize);
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
        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string siteId, string categoryId)
        {
            return this.GetAllNewsByCategoryId(categoryId, siteId).Take(NewsConfiguration.DefaultListSize);
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
        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize)
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
        /// <param name="pageNumber">
        /// The pageNumber.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize, int pageNumber)
        {
            return this.GetNewsByCategoryId(categoryId, listSize, pageNumber);
        }

        /// <summary>
        /// The get all news by category id.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="siteId">
        /// The site id.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        protected virtual IEnumerable<UmbracoNews> GetAllNewsByCategoryId(string categoryId, string siteId = null)
        {
            var searchCriteria = this.Searcher.CreateSearchCriteria();
            var query = searchCriteria.Field(CategoriesAlias, categoryId);

            if (!string.IsNullOrEmpty(siteId))
            {
                query.And().Field(SiteIndexFieldName, siteId);
            }

            var newsList = new List<UmbracoNews>();

            var sequence = 1;
            
            var searchResults = this.Searcher.Search(query.Compile());
            foreach (var result in searchResults)
            {
                var news = this.GetNews(result.Id.ToString(CultureInfo.InvariantCulture));
                news.Sequence = sequence++;
                newsList.Add(news);
            }

            return newsList;
        }
    }
}
