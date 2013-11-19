// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmbracoNewsConfigurationStrategy.cs" company="Gravypowered">
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
//   Defines the UmbracoNewsConfigurationStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.News.Umbraco
{
    using Examine;

    using Gravyframe.Configuration;
    using Gravyframe.Configuration.Umbraco;
    using Gravyframe.Data.News;
    using Gravyframe.Data.Umbraco.News;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Models.Umbraco;
    using Gravyframe.Service;
    using Gravyframe.Service.News;

    /// <summary>
    /// The umbraco news app host configuration strategy.
    /// </summary>
    public class UmbracoNewsConfigurationStrategy : NewsConfigurationStrategy
    {
        /// <summary>
        /// The configure container.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public override void ConfigureContainer(Funq.Container container)
        {
            container.Register<ISearcher>(ExamineManager.Instance.SearchProviderCollection["GravyframeNewsSearcher"]);
            container.Register<INodeFactoryFacade>(new NodeFactoryFacade());
            container.Register<INewsConfiguration>(
                new UmbracoNewsConfiguration(container.Resolve<INodeFactoryFacade>(), 1069));

            container.Register<NewsDao<UmbracoNews>>(
                new UmbracoNewsDao(
                    container.Resolve<INewsConfiguration>(),
                    container.Resolve<INodeFactoryFacade>(),
                    container.Resolve<ISearcher>()));

            container.Register<IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>>>(
                new NewsResponseHydrogenationTaskList(container));
        }

        public override System.Type GetServiceType()
        {
            return typeof(NewsService<UmbracoNews>);
        }
    }
}