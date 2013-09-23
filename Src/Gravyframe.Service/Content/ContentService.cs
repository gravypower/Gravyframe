using System;
using System.Collections.Generic;

namespace Gravyframe.Service.Content
{
    public class ContentService : Service<ContentRequest, ContentResponse, ContentService.NullContentRequestException>
    {
        public ContentService(IEnumerable<Task<ContentRequest, ContentResponse>> tasks):base(tasks)
        {
        }

        [Serializable]
        public class NullContentRequestException : NullRequestException
        {
        }
    }
}
