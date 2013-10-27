using System.Collections.Generic;
using Gravyframe.Constants;

namespace Gravyframe.Data.News
{
    public abstract class NewsDao<TNews> where TNews: Models.News
    {
        public readonly INewsConstants NewsConstants;

        protected NewsDao()
        {
        }

        protected NewsDao(INewsConstants newsConstants)
        {
            NewsConstants = newsConstants;
        }

        public abstract TNews GetNews(string newsId);

        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId);

        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId, int listSize);

        public abstract IEnumerable<TNews> GetNewsByCategoryId(string categoryId, int listSize, int page);

        protected static int CalculateNumberToSkip(int listSize, int page)
        {
            return (page - 1) * listSize;
        }

    }
}
