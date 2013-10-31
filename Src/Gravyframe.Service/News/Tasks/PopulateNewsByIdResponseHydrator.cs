using System;
using System.Collections.Generic;
using Gravyframe.Configuration;
using Gravyframe.Data.News;

namespace Gravyframe.Service.News.Tasks
{
    public class PopulateNewsByIdResponseHydrator<TNews> : NewsResponseHydrator<TNews>
        where TNews : Models.News
    {
        public PopulateNewsByIdResponseHydrator(NewsDao<TNews> newsDao, INewsConfiguration newsConfiguration)
            : base(newsDao, newsConfiguration)
        {
        }

        public override void PopulateResponse(NewsRequest request, NewsResponse<TNews> response)
        {
            response.News = NewsDao.GetNews(request.NewsId);
        }

        public override IEnumerable<string> ValidateResponse(NewsRequest request)
        {
            if (String.IsNullOrEmpty(request.NewsId))
                return new List<string>
                    {
                        NewsConfiguration.NewsIdError
                    };
            return new List<string>();
        }
    }
}
