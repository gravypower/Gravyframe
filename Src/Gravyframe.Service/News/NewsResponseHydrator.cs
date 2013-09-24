using Gravyframe.Constants;
using Gravyframe.Data.News;

namespace Gravyframe.Service.News
{
    public abstract class NewsResponseHydrator : ResponseHydrator<NewsRequest, NewsResponse>
    {
        protected readonly INewsConstants NewsConstants;
        protected readonly INewsDao NewsDao;

        protected NewsResponseHydrator(INewsConstants newsConstants, INewsDao newsDao)
        {
            NewsConstants = newsConstants;
            NewsDao = newsDao;
        }
    }
}
