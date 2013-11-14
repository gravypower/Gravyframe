using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Umbraco.News
{
    using Models.Umbraco;
    using Service;
    using Service.News;

    public class UmbracoNewsService : NewsService<UmbracoNews>, IService
    {
        public UmbracoNewsService(IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>> responseHydrogenationTasks)
            : base(responseHydrogenationTasks)
        {
        }
    }
}