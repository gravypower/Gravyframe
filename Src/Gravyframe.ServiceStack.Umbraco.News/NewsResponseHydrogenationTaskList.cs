// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsResponseHydrogenationTaskList.cs" company="Gravypowered">
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
//   Defines the NewsResponseHydrogenationTaskList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.News.Umbraco
{
    using System.Collections;
    using System.Collections.Generic;

    using Funq;

    using Gravyframe.Configuration;
    using Gravyframe.Data.News;
    using Gravyframe.Service;
    using Gravyframe.Service.News;
    using Gravyframe.Service.News.Tasks;

    /// <summary>
    /// The news response hydrogenation task list.
    /// </summary>
    public class NewsResponseHydrogenationTaskList : IResponseHydrogenationTaskList<NewsRequest, NewsResponse<Models.Umbraco.UmbracoNews>>
    {
        private readonly Container container;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsResponseHydrogenationTaskList"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public NewsResponseHydrogenationTaskList(Container container)
        {
            this.container = container;
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator<ResponseHydrator<NewsRequest, NewsResponse<Models.Umbraco.UmbracoNews>>> GetEnumerator()
        {
            return this.GetTasks();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetTasks();
        }

        private IEnumerator<ResponseHydrator<NewsRequest, NewsResponse<Models.Umbraco.UmbracoNews>>> GetTasks()
        {
            yield return new PopulateNewsByCategoryIdResponseHydrator<Models.Umbraco.UmbracoNews>(
                this.container.Resolve<NewsDao<Models.Umbraco.UmbracoNews>>(),
                this.container.Resolve<INewsConfiguration>());

            yield return new PopulateNewsByIdResponseHydrator<Models.Umbraco.UmbracoNews>(
                this.container.Resolve<NewsDao<Models.Umbraco.UmbracoNews>>(),
                this.container.Resolve<INewsConfiguration>());
        }
    }
}