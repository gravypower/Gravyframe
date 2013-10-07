using System.Collections.Generic;
using Gravyframe.Constants;

namespace Gravyframe.Data.News
{
    public abstract class NewsDao
    {
        public readonly INewsConstants NewsConstants;

        protected NewsDao(INewsConstants newsConstants)
        {
            NewsConstants = newsConstants;
        }

        public abstract Models.News GetNews(string newsId);

        public abstract IEnumerable<Models.News> GetNewsByCategoryId(string categoryId);
    }
}
