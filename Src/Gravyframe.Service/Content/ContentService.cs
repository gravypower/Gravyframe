using System;
using System.Collections.Generic;

namespace Gravyframe.Service.Content
{
    public class ContentService : Service<ContentRequest, ContentResponse, ContentService.NullContentRequestException>
    {
        public ContentService(IEnumerable<ResponseHydrator<ContentRequest, ContentResponse>> responseHydrogenationTasks):base(responseHydrogenationTasks)
        {
        }

        [Serializable]
        public class NullContentRequestException : NullRequestException
        {
        }
    }
}
