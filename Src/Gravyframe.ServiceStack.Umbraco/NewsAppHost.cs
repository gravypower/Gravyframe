using System.Collections.Generic;
using Examine;
using Funq;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Models.Umbraco;
using Gravyframe.Service;
using Gravyframe.Service.News;
using Gravyframe.Service.News.Tasks;
using ServiceStack.WebHost.Endpoints;
using Gravyframe.Configuration.Umbraco;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class NewsAppHost : AppHostBase 
    {
        public NewsAppHost () : base("Gravyframe Content Web Services", typeof(NewsService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            container.Register<INodeFactoryFacade>(new NodeFactoryFacade());
            container.Register<INewsConfiguration>(new UmbracoNewsConfiguration(Resolve<INodeFactoryFacade>(), 1069));

            container.Register<NewsDao<UmbracoNews>>(new UmbracoNewsDao(Resolve<INewsConfiguration>(), Resolve<INodeFactoryFacade>(), Resolve<ISearcher>()));
            container.Register<IContentConfiguration>(constants => new ContentConfiguration());

            container.Register<IEnumerable<ResponseHydrator<NewsRequest, NewsResponse<UmbracoNews>>>>(
                new List<ResponseHydrator<NewsRequest, NewsResponse<UmbracoNews>>>
                    {
                        new PopulateNewsByCategoryIdResponseHydrator<UmbracoNews>(Resolve<NewsDao<UmbracoNews>>(), Resolve<INewsConfiguration>()),
                        new PopulateNewsByIdResponseHydrator<UmbracoNews>(Resolve<NewsDao<UmbracoNews>>(), Resolve<INewsConfiguration>())
                    }
                );

            Routes.Add<NewsRequest>("/NewsService/");
            Routes.Add<NewsRequest>("/NewsService/{NewsId}");
            Routes.Add<NewsRequest>("/NewsService/Category/{CategoryId}");
        }
    }
}