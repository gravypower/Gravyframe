using System.Reflection;
using Gravyframe.Service.News;
using ServiceStack.WebHost.Endpoints;

namespace Gravyframe.ServiceStack
{
    using Funq;

    public abstract class NewsAppHost : AppHostHttpListenerBase
    {
        protected NewsAppHost(string serviceName, params Assembly[] assembliesWithServices):base(serviceName, assembliesWithServices)
        {
        }

        public override void Configure(Container container)
        {
            RegisterExternalDependencies();
            RegisterDependencies();
            RegisterRoutes();
        }

        protected abstract void RegisterDependencies();
        protected abstract void RegisterExternalDependencies();

        protected virtual void RegisterRoutes()
        {
            Routes.Add<NewsRequest>("/NewsService/");
            Routes.Add<NewsRequest>("/NewsService/{NewsId}");
            Routes.Add<NewsRequest>("/NewsService/Category/{CategoryId}");
        }
    }
}
