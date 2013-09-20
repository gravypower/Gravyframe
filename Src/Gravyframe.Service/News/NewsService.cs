using System;

namespace Gravyframe.Service.News
{
    public class NewsService : Service<NewsRequest, NewsResponse>
    {
        public override NewsResponse Get(NewsRequest request)
        {
            if (request == null)
                throw new NullNewsRequestException();

            return new NewsResponse();
        }

        [Serializable]
        public class NullNewsRequestException : NullRequestException
        {
        }
    }
}
