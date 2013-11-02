using Funq;
using Gravyframe.Service.News;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack
{
    public abstract class NewsAppHostConfigurationStrategy
    {
        public abstract void ConfigureContainer(Container container);

        public virtual void ConfigureRoutes(IServiceRoutes routes)
        {
            routes.Add<NewsRequest>("/NewsService/");
            routes.Add<NewsRequest>("/NewsService/{NewsId}");
            routes.Add<NewsRequest>("/NewsService/Category/{CategoryId}");
        }
    }
}
