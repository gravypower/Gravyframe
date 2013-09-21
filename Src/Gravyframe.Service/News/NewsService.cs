using System;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.News
{
    public class NewsService : Service<NewsRequest, NewsResponse, NewsService.NullNewsRequestException>
    {
        [Serializable]
        public class NullNewsRequestException : NullRequestException
        {
        }

        protected override NewsResponse CreateResponce(NewsRequest request)
        {
           return new NewsResponse();
        }

        protected override NewsResponse ValidateRequest(NewsRequest request)
        {
            if (!String.IsNullOrEmpty(request.NewsId))
                return new NewsResponse {Code = ResponceCodes.Failure};

            return new NewsResponse();

        }
    }
}
