// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsDataProviderFacade.cs" company="Gravypowered">
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
//   Defines the NewsDataProviderFacade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Kernel.Sitefinity.Facades
{
    using Telerik.Sitefinity.Modules.News;
    using Telerik.Sitefinity.News.Model;

    /// <summary>
    /// The news data provider facade.
    /// </summary>
    public class NewsDataProviderFacade : INewsDataProviderFacade
    {
        private readonly NewsDataProvider newsDataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsDataProviderFacade"/> class.
        /// </summary>
        /// <param name="newsDataProvider">
        /// The news data provider.
        /// </param>
        public NewsDataProviderFacade(NewsDataProvider newsDataProvider)
        {
            this.newsDataProvider = newsDataProvider;
        }

        /// <summary>
        /// The get news item.
        /// </summary>
        /// <param name="id">
        /// The id of the new item.
        /// </param>
        /// <returns>
        /// The <see cref="NewsItem"/>.
        /// </returns>
        public NewsItem GetNewsItem(System.Guid id)
        {
            return this.newsDataProvider.GetNewsItem(id);
        }
    }
}
