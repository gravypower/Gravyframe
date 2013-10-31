using Gravyframe.Configuration;
using Gravyframe.Data.News;

namespace Gravyframe.Service.News
{
    public abstract class NewsResponseHydrator : ResponseHydrator<NewsRequest, NewsResponse>        
    {
        protected readonly INewsConstants NewsConstants;
        protected readonly NewsDao<Models.News> NewsDao;

        protected NewsResponseHydrator(INewsConstants newsConstants, NewsDao<Models.News> newsDao)
        {
            NewsConstants = newsConstants;
            NewsDao = newsDao;
        }
    }
}
