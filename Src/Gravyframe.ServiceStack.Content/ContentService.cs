using System.Collections.Generic;
using Gravyframe.Data.Content;
using Gravyframe.Service;
using Gravyframe.Service.Content;
using Gravyframe.Service.Messages;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Content
{
    public class ContentService : Service.Content.ContentService, IService
    {
        public ContentService(IEnumerable<Task<ContentRequest, ContentResponse>> tasks)
            : base(tasks)
        {
        }
    }
}