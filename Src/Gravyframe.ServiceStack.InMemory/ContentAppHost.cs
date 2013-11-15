// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentAppHost.cs" company="Gravypowered">
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
//   The content app host.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.InMemory
{
    using System.Collections.Generic;

    using Funq;

    using Gravyframe.Configuration;
    using Gravyframe.Data.Content;
    using Gravyframe.Data.InMemory.Content;
    using Gravyframe.Service;
    using Gravyframe.Service.Content;
    using Gravyframe.Service.Content.Tasks;

    using global::ServiceStack.WebHost.Endpoints;

    /// <summary>
    /// The content app host.
    /// </summary>
    public class ContentAppHost : AppHostBase 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentAppHost"/> class.
        /// </summary>
        public ContentAppHost()
            : base("Gravyframe Content Web Services", typeof(ContentService).Assembly)
        {
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public override void Configure(Container container)
        {
            container.Register<ContentDao<Models.Content>>(dao => new InMemoryContentDao());
            container.Register<IContentConfiguration>(constants => new ContentConfiguration());

            container.Register<IEnumerable<ResponseHydrator<ContentRequest, ContentResponse>>>(responseHydrationTasks => 
                new List<ResponseHydrator<ContentRequest, ContentResponse>>
                    {
                        new PopulateContentByCategoryIdResponseHydrator(container.Resolve<ContentDao<Models.Content>>(), container.Resolve<IContentConfiguration>()),
                        new PopulateContentByIdResponseHydrator(container.Resolve<ContentDao<Models.Content>>(), container.Resolve<IContentConfiguration>())
                    });

            Routes.Add<ContentRequest>("/ContentService/");
            Routes.Add<ContentRequest>("/ContentService/{ContentId}");
            Routes.Add<ContentRequest>("/ContentService/Category/{CategoryId}");
        }
    }
}