using System.Collections.Generic;
using Gravyframe.Models.Umbraco;
using Gravyframe.Service;
using Gravyframe.Service.News;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class NewsService : NewsService<UmbracoNews>, IService
    {
        public NewsService(IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>> responseHydrogenationTasks)
            : base(responseHydrogenationTasks)
        {
        }
    }
}