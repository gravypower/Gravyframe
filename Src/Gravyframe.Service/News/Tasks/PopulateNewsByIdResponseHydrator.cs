using System;
using System.Collections.Generic;
using Gravyframe.Configuration;
using Gravyframe.Data.News;

namespace Gravyframe.Service.News.Tasks
{
    public class PopulateNewsByIdResponseHydrator : NewsResponseHydrator
    {
        public PopulateNewsByIdResponseHydrator(INewsConstants newsConstants, NewsDao<Models.News> newsDao)
            : base(newsConstants, newsDao)
        {
        }

        public override void PopulateResponse(NewsRequest request, NewsResponse response)
        {
            response.News = NewsDao.GetNews(request.NewsId);
        }

        public override IEnumerable<string> ValidateResponse(NewsRequest request)
        {
            if (String.IsNullOrEmpty(request.NewsId))
                return new List<string>
                    {
                        NewsConstants.NewsIdError
                    };
            return new List<string>();
        }
    }
}
