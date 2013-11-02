using System.Collections.Generic;
using Funq;
using Gravyframe.Service.News;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack
{
    public abstract class NewsAppHostConfigurationStrategy
    {
        private readonly IEnumerable<string> _sites;

        protected NewsAppHostConfigurationStrategy()
        {
            _sites = new List<string>{string.Empty};
        }
        
        protected NewsAppHostConfigurationStrategy(IEnumerable<string> sites)
        {
            _sites = sites;
        }

        public const string NewsServiceRestPath = "/NewsService";

        public const string CategoryIdToken = "{CategoryId}";
        public const string NewsByCategoryIdServiceRestPath = NewsServiceRestPath + "/Category/" + CategoryIdToken;

        public const string NewsIdToken = "{NewsId}";
        public const string NewsByIdServiceRestPath = NewsServiceRestPath + "/" + NewsIdToken;

        public abstract void ConfigureContainer(Container container);

        public virtual void ConfigureRoutes(IServiceRoutes routes)
        {
            foreach (var site in _sites)
            {
                var siteRoute = string.Empty;
                if (!string.IsNullOrEmpty(site))
                {
                    siteRoute = "/" + site;
                }

                routes.Add<NewsRequest>(siteRoute + GetNewsServiceRestPath());
                routes.Add<NewsRequest>(siteRoute + GetNewsByIdNewsServiceRestPath());
                routes.Add<NewsRequest>(siteRoute + GetNewsByCategoryIdNewsServiceRestPath());
            }
        }

        public virtual string GetNewsServiceRestPath()
        {
            return NewsServiceRestPath;
        }

        public virtual string GetNewsByIdNewsServiceRestPath(string newsId = null)
        {
            return newsId != null ? NewsByIdServiceRestPath.Replace(NewsIdToken, newsId) : NewsByIdServiceRestPath;
        }

        public virtual string GetNewsByCategoryIdNewsServiceRestPath(string categoryId = null)
        {
            return categoryId != null ? NewsByCategoryIdServiceRestPath.Replace(CategoryIdToken, categoryId) : NewsByCategoryIdServiceRestPath;
        }
    }
}
