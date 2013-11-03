using System;
using System.Collections.Generic;
using Gravyframe.Configuration;
using Gravyframe.Data.News;

namespace Gravyframe.Service.News.Tasks
{
    public class PopulateNewsByCategoryIdResponseHydrator<TNews> : NewsResponseHydrator<TNews>
        where TNews : Models.News
    {
        public PopulateNewsByCategoryIdResponseHydrator(NewsDao<TNews> newsDao, INewsConfiguration newsConfiguration)
            : base(newsDao, newsConfiguration)
        {
        }

        public override IEnumerable<string> ValidateResponse(NewsRequest request)
        {
            if (String.IsNullOrEmpty(request.CategoryId))
                return new List<string>
                    {
                        NewsConfiguration.NewsCategoryIdError
                    };

            return new List<string>();
        }

        public override void PopulateResponse(NewsRequest request, NewsResponse<TNews> response)
        {
            response.NewsList = string.IsNullOrEmpty(request.SiteId)
                ? NewsDao.GetNewsByCategoryId(request.CategoryId)
                : NewsDao.GetNewsByCategoryId(request.SiteId, request.CategoryId);
        }
    }
}
