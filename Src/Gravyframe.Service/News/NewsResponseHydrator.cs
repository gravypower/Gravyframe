using Gravyframe.Constants;
using Gravyframe.Data.News;

namespace Gravyframe.Service.News
{
    public abstract class NewsResponseHydrator : ResponseHydrator<NewsRequest, NewsResponse>
    {
        protected readonly INewsConstants NewsConstants;
        protected readonly NewsDao NewsDao;

        protected NewsResponseHydrator(INewsConstants newsConstants, NewsDao newsDao)
        {
            NewsConstants = newsConstants;
            NewsDao = newsDao;
        }
    }
}
