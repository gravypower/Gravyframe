using System;

namespace Gravyframe.Service.News
{
    public class NewsService : Service<NewsRequest, NewsResponse, NewsService.NullNewsRequestException>
    {
        [Serializable]
        public class NullNewsRequestException : NullRequestException
        {
        }

        protected override NewsResponse CreateResponce(NewsRequest request, NewsResponse responce)
        {
            return responce;
        }

        protected override NewsResponse ValidateRequest(NewsRequest request)
        {
            return new NewsResponse();
        }
    }
}
