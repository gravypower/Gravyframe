// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentDao.cs" company="Gravypowered">
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
//   Defines the ContentDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Data.Umbraco.Content
{
    using System.Collections.Generic;
    using System.Globalization;

    using Examine;

    using Gravyframe.Configuration;
    using Gravyframe.Data.Content;
    using Gravyframe.Kernel.Umbraco.Extension;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Models.Umbraco;

    /// <summary>
    /// The content dao.
    /// </summary>
    public class ContentDao : ContentDao<Content>
    {
        /// <summary>
        /// The title alias.
        /// </summary>
        public const string TitleAlias = "title";

        /// <summary>
        /// The body alias.
        /// </summary>
        public const string BodyAlias = "body";

        /// <summary>
        /// The categories alias.
        /// </summary>
        public const string CategoriesAlias = "categories";

        /// <summary>
        /// The name of the index Field for the site.
        /// </summary>
        public const string SiteIndexFieldName = "site";

        private readonly INodeFactoryFacade nodeFactoryFacade;

        private readonly ContentConfiguration contentConfiguration;

        protected readonly ISearcher Searcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentDao"/> class.
        /// </summary>
        /// <param name="nodeFactoryFacade">
        /// The node factory facade.
        /// </param>
        /// <param name="contentConfiguration">
        /// The content configuration.
        /// </param>
        /// <param name="searcher">
        /// The searcher.
        /// </param>
        public ContentDao(INodeFactoryFacade nodeFactoryFacade, ContentConfiguration contentConfiguration, ISearcher searcher)
        {
            this.nodeFactoryFacade = nodeFactoryFacade;
            this.contentConfiguration = contentConfiguration;
            this.Searcher = searcher;
        }

        /// <summary>
        /// The get content.
        /// </summary>
        /// <param name="contentId">
        /// The content id.
        /// </param>
        /// <returns>
        /// The <see cref="Content"/>.
        /// </returns>
        public override Content GetContent(string contentId)
        {
            var node = this.nodeFactoryFacade.GetNode(int.Parse(contentId));

            if (node == null || node.Id == 0)
            {
                return null;
            }

            return new Content
                       {
                           Id = node.Id,
                           Body = node.GetProperty(BodyAlias, string.Empty),
                           Title = node.GetProperty(TitleAlias, string.Empty)
                       };
        }

        /// <summary>
        /// The get content by category.
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
        public override IEnumerable<Content> GetContentByCategory(string categoryId)
        {
            var searchCriteria = this.Searcher.CreateSearchCriteria();
            var query = searchCriteria.Field(CategoriesAlias, categoryId);

            var newsList = new List<Content>();

            var searchResults = this.Searcher.Search(query.Compile());
            foreach (var result in searchResults)
            {
                var content = this.GetContent(result.Id.ToString(CultureInfo.InvariantCulture));
                newsList.Add(content);
            }

            return newsList;
        }
    }
}
