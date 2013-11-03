using Funq;
using Gravyframe.Service.News;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack
{
    public abstract class NewsAppHostConfigurationStrategy
    {
        public const string SiteIdToken = "{SiteId}";

        public const string NewsServiceRestPath = "/NewsService";

        public const string CategoryIdToken = "{CategoryId}";
        public const string NewsByCategoryIdServiceRestPath = NewsServiceRestPath + "/Category/" + CategoryIdToken;

        public const string NewsIdToken = "{NewsId}";
        public const string NewsByIdServiceRestPath = NewsServiceRestPath + "/" + NewsIdToken;

        public abstract void ConfigureContainer(Container container);

        public virtual void ConfigureRoutes(IServiceRoutes routes)
        {
            routes.Add<NewsRequest>("/" + SiteIdToken + GetNewsServiceRestPath());
            routes.Add<NewsRequest>("/" + SiteIdToken + GetNewsByIdNewsServiceRestPath());
            routes.Add<NewsRequest>("/" + SiteIdToken + GetNewsByCategoryIdNewsServiceRestPath());

            routes.Add<NewsRequest>(GetNewsServiceRestPath());
            routes.Add<NewsRequest>(GetNewsByIdNewsServiceRestPath());
            routes.Add<NewsRequest>(GetNewsByCategoryIdNewsServiceRestPath());
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
