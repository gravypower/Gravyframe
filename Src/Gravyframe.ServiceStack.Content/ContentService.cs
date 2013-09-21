using Gravyframe.Data.Content;
using Gravyframe.Service.Content;
using Gravyframe.Service.Messages;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Content
{
    public class ContentService : Service.Content.ContentService, IService
    {
        public ContentService(IContentDao contentDao, IContentConstants contentConstants)
            : base(contentDao, contentConstants)
        {
        }

        private static bool IsRequestASuccess(ContentResponse responce)
        {
            return responce.Code == ResponceCodes.Success;
        }
    }
}