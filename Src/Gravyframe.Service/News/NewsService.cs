using System;
using System.Collections.Generic;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.News
{
    public class NewsService : Service<NewsRequest, NewsResponse, NewsService.NullNewsRequestException>
    {
        private readonly INewsConstants _newsConstants;

        [Serializable]
        public class NullNewsRequestException : NullRequestException
        {
        }

        public NewsService(INewsConstants newsConstants)
        {
            _newsConstants = newsConstants;
        }

        protected override NewsResponse CreateResponce(NewsRequest request)
        {
           return new NewsResponse();
        }

        protected override NewsResponse ValidateRequest(NewsRequest request)
        {
            if (String.IsNullOrEmpty(request.NewsId))
            {
                return new NewsResponse
                    {
                        Code = ResponceCodes.Failure,
                        Errors = new List<string>{ _newsConstants.NewsIdError}
                    };
            }

            return new NewsResponse();

        }
    }
}
