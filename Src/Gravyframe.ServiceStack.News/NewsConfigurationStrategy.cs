// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsConfigurationStrategy.cs" company="Gravypowered">
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
//   The news app host configuration strategy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.News
{
    using Funq;

    using global::ServiceStack.ServiceHost;

    using Gravyframe.Service.News;

    /// <summary>
    /// The news app host configuration strategy.
    /// </summary>
    public abstract class NewsConfigurationStrategy : IConfigurationStrategy
    {
        /// <summary>
        /// The site id token.
        /// </summary>
        public const string SiteIdToken = "{SiteId}";

        /// <summary>
        /// The news service rest path.
        /// </summary>
        public const string NewsServiceRestPath = "/NewsService";

        /// <summary>
        /// The category id token.
        /// </summary>
        public const string CategoryIdToken = "{CategoryId}";

        /// <summary>
        /// The news by category id service rest path.
        /// </summary>
        public const string NewsByCategoryIdServiceRestPath = NewsServiceRestPath + "/Category/" + CategoryIdToken;

        /// <summary>
        /// The news id token.
        /// </summary>
        public const string NewsIdToken = "{NewsId}";

        /// <summary>
        /// The news by id service rest path.
        /// </summary>
        public const string NewsByIdServiceRestPath = NewsServiceRestPath + "/" + NewsIdToken;

        /// <summary>
        /// The configure container.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public abstract void ConfigureContainer(Container container);

        /// <summary>
        /// The configure routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public virtual void ConfigureRoutes(IServiceRoutes routes)
        {
            routes.Add<NewsRequest>("/" + SiteIdToken + this.GetNewsServiceRestPath());
            routes.Add<NewsRequest>("/" + SiteIdToken + this.GetNewsByIdNewsServiceRestPath());
            routes.Add<NewsRequest>("/" + SiteIdToken + this.GetNewsByCategoryIdNewsServiceRestPath());

            routes.Add<NewsRequest>(this.GetNewsServiceRestPath());
            routes.Add<NewsRequest>(this.GetNewsByIdNewsServiceRestPath());
            routes.Add<NewsRequest>(this.GetNewsByCategoryIdNewsServiceRestPath());
        }

        /// <summary>
        /// The get news service rest path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public virtual string GetNewsServiceRestPath()
        {
            return NewsServiceRestPath;
        }

        /// <summary>
        /// The get news by id news service rest path.
        /// </summary>
        /// <param name="newsId">
        /// The news id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public virtual string GetNewsByIdNewsServiceRestPath(string newsId = null)
        {
            return newsId != null ? NewsByIdServiceRestPath.Replace(NewsIdToken, newsId) : NewsByIdServiceRestPath;
        }

        /// <summary>
        /// The get news by category id news service rest path.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public virtual string GetNewsByCategoryIdNewsServiceRestPath(string categoryId = null)
        {
            return categoryId != null ? NewsByCategoryIdServiceRestPath.Replace(CategoryIdToken, categoryId) : NewsByCategoryIdServiceRestPath;
        }

        public abstract System.Type GetServiceType();
    }
}
