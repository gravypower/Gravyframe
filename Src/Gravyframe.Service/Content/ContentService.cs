using System;
using System.Collections.Generic;

namespace Gravyframe.Service.Content
{
    public class ContentService : Service<ContentRequest, ContentResponse, ContentService.NullContentRequestException>
    {
        public ContentService(IEnumerable<ResponseHydrator<ContentRequest, ContentResponse>> responseHydratationTasks):base(responseHydratationTasks)
        {
        }

        [Serializable]
        public class NullContentRequestException : NullRequestException
        {
        }
    }
}
