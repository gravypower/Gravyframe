using Examine;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Models.Umbraco;
using Gravyframe.Service;
using Gravyframe.Service.News;
using Gravyframe.Configuration.Umbraco;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class UmbracoNewsAppHost : NewsAppHost 
    {
        public UmbracoNewsAppHost () : base("Gravyframe News Web Services", typeof(UmbracoNewsService).Assembly)
        {
        }

        protected override void RegisterExternalDependencies()
        {
            Register<ISearcher>(ExamineManager.Instance.SearchProviderCollection["ExternalSearcher"]);
            Register<INodeFactoryFacade>(new NodeFactoryFacade());
            Register<INewsConfiguration>(new UmbracoNewsConfiguration(Resolve<INodeFactoryFacade>(), 1069));
        }

        protected override void RegisterDependencies()
        {
            Register<NewsDao<UmbracoNews>>(new UmbracoNewsDao(Resolve<INewsConfiguration>(),
            Resolve<INodeFactoryFacade>(), Resolve<ISearcher>()));
            Register<IContentConfiguration>(new ContentConfiguration());

            Register<IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>>>(
               new NewsResponseHydrogenationTaskList(Container)
                );
        }
    }
}