using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gravyframe.Data.Content;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Content
{
    public class ContentService : Service.Content.ContentService, IService
    {
        public ContentService(IContentDao contentDao):base(contentDao)
        {
        }
    }
}