using Examine;
using Funq;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Models.Umbraco;
using Gravyframe.Service;
using Gravyframe.Service.News;
using ServiceStack.WebHost.Endpoints;
using Gravyframe.Configuration.Umbraco;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class NewsAppHost : AppHostHttpListenerBase 
    {
        public NewsAppHost () : base("Gravyframe Content Web Services", typeof(NewsService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            this.RegisterExternalDependencies();

            Register<NewsDao<UmbracoNews>>(new UmbracoNewsDao(Resolve<INewsConfiguration>(),
            Resolve<INodeFactoryFacade>(), Resolve<ISearcher>()));
            Register<IContentConfiguration>(new ContentConfiguration());

            Register<IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>>>(
               new NewsResponseHydrogenationTaskList(Container)
                );

            Routes.Add<NewsRequest>("/NewsService/");
            Routes.Add<NewsRequest>("/NewsService/{NewsId}");
            Routes.Add<NewsRequest>("/NewsService/Category/{CategoryId}");
        }

        public virtual void RegisterExternalDependencies()
        {
            Register<ISearcher>(ExamineManager.Instance.SearchProviderCollection["ExternalSearcher"]);
            Register<INodeFactoryFacade>(new NodeFactoryFacade());
            Register<INewsConfiguration>(new UmbracoNewsConfiguration(Resolve<INodeFactoryFacade>(), 1069));
        }
    }
}