// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmbracoNewsService.cs" company="Gravypowered">
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
//   Defines the UmbracoNewsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.Umbraco.News
{
    using Gravyframe.Models.Umbraco;
    using Gravyframe.Service;
    using Gravyframe.Service.News;

    using global::ServiceStack.ServiceHost;

    /// <summary>
    /// The umbraco news service.
    /// </summary>
    public class UmbracoNewsService : NewsService<UmbracoNews>, IService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoNewsService"/> class.
        /// </summary>
        /// <param name="responseHydrogenationTasks">
        /// The response hydrogenation tasks.
        /// </param>
        public UmbracoNewsService(IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>> responseHydrogenationTasks)
            : base(responseHydrogenationTasks)
        {
        }
    }
}