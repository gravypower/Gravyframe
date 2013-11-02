using Gravyframe.Models.Umbraco;
using Gravyframe.Service;
using Gravyframe.Service.News;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Umbraco.News
{
    public class UmbracoNewsService : NewsService<UmbracoNews>, IService
    {
        public UmbracoNewsService(IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>> responseHydrogenationTasks)
            : base(responseHydrogenationTasks)
        {
        }
    }
}