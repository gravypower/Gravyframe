using System.Collections.Generic;
using Examine;
using Gravyframe.Configuration;
using Gravyframe.Configuration.Umbraco;
using Gravyframe.Data.News;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Models.Umbraco;
using Gravyframe.Service;
using Gravyframe.Service.News;

namespace Gravyframe.ServiceStack.Umbraco.News
{
    public class UmbracoNewsAppHostConfigurationStrategy : NewsAppHostConfigurationStrategy
    {
        public override void ConfigureContainer(Funq.Container container)
        {
            container.Register<ISearcher>(ExamineManager.Instance.SearchProviderCollection["ExternalSearcher"]);
            container.Register<INodeFactoryFacade>(new NodeFactoryFacade());
            container.Register<INewsConfiguration>(new UmbracoNewsConfiguration(container.Resolve<INodeFactoryFacade>(), 1069));
            container.Register<NewsDao<UmbracoNews>>(new UmbracoNewsDao(container.Resolve<INewsConfiguration>(),
            container.Resolve<INodeFactoryFacade>(), container.Resolve<ISearcher>()));

            container.Register<IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>>>(
               new NewsResponseHydrogenationTaskList(container)
                );
        }
    }
}