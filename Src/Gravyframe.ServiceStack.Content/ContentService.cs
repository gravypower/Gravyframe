using Gravyframe.Data.Content;
using Gravyframe.Service.Content;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Content
{
    public class ContentService : Service.Content.ContentService, IService
    {
        public ContentService(IContentDao contentDao, IContentConstants contentConstants)
            : base(contentDao, contentConstants)
        {
        }
    }
}