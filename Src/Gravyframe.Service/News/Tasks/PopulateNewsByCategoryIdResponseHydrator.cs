using System;
using System.Collections.Generic;
using Gravyframe.Data.News;

namespace Gravyframe.Service.News.Tasks
{
    public class PopulateNewsByCategoryIdResponseHydrator : NewsResponseHydrator
    {
        public PopulateNewsByCategoryIdResponseHydrator(INewsConstants newsConstants, INewsDao newsDao) : base(newsConstants, newsDao)
        {
        }

        public override IEnumerable<string> ValidateResponse(NewsRequest request)
        {
            if (String.IsNullOrEmpty(request.CategoryId))
                return new List<string>
                    {
                        NewsConstants.NewsCategoryIdError
                    };

            return new List<string>();
        }

        public override void PopulateResponse(NewsRequest request, NewsResponse response)
        {
            response.NewsList = NewsDao.GetNewsByCategoryId(request.CategoryId);
        }
    }
}
