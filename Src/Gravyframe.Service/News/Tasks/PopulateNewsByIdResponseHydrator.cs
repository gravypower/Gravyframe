using System;
using System.Collections.Generic;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Service.Messages;

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
            var news = string.IsNullOrEmpty(request.SiteId)
                ? NewsDao.GetNews(request.NewsId)
                : NewsDao.GetNews(request.SiteId, request.NewsId);

            if (news != null)
            {
                response.News = news;
            }
            else
            {
                response.Code = ResponceCodes.Failure;
            }
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
