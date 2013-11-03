using System.Collections.Generic;
using Gravyframe.Configuration;

namespace Gravyframe.Data.News
{
    public abstract class NewsDao<TNews> where TNews: Models.News
    {
        public readonly INewsConfiguration NewsConfiguration;

        protected NewsDao()
        {
        }

        protected NewsDao(INewsConfiguration newsConfiguration)
        {
            NewsConfiguration = newsConfiguration;
        }

        public abstract TNews GetNews(string newsId);

        public abstract TNews GetNews(string siteId, string newsId);


        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId);

        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId, int listSize);

        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId, int listSize, int page);

        public abstract IEnumerable<TNews> GetNewsByCategoryId(string siteId, string categoryId);

        public abstract IEnumerable<TNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize);

        public abstract IEnumerable<TNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize, int page);

        protected static int CalculateNumberToSkip(int listSize, int page)
        {
            return (page - 1) * listSize;
        }

    }
}
