using Gravyframe.Service;
using Gravyframe.Service.Content;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class ContentService : Service.Content.ContentService, IService
    {
        public ContentService(IResponseHydrogenationTaskList<ContentRequest, ContentResponse> responseHydrogenationTasks)
            : base(responseHydrogenationTasks)
        {
        }
    }
}