using System.Collections.Generic;
using Gravyframe.Constants;

namespace Gravyframe.Data.News
{
    public abstract class NewsDao
    {
        public readonly INewsConstants NewsConstants;

        protected NewsDao()
        {
        }

        protected NewsDao(INewsConstants newsConstants)
        {
            NewsConstants = newsConstants;
        }

        public abstract Models.News GetNews(string newsId);

        public abstract IEnumerable<Models.News> GetNewsByCategoryId(string categoryId);

        public abstract IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize);

        public abstract IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize, int page);

    }
}
