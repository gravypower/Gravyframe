using Gravyframe.Configuration;
using Gravyframe.Data.News;

namespace Gravyframe.Service.News
{
    public abstract class NewsResponseHydrator<TNews>  : ResponseHydrator<NewsRequest, NewsResponse<TNews>>
        where TNews : Models.News
    {
        protected readonly INewsConfiguration NewsConfiguration;
        protected readonly NewsDao<TNews> NewsDao;

        protected NewsResponseHydrator(NewsDao<TNews> newsDao, INewsConfiguration newsConfiguration)
        {
            NewsConfiguration = newsConfiguration;
            NewsDao = newsDao;
        }
    }
}
