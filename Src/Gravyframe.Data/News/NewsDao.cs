using System.Collections.Generic;

namespace Gravyframe.Data.News
{
    public abstract class NewsDao : INewsDao
    {
        public abstract Models.News GetNews(string newsId);

        public abstract IEnumerable<Models.News> GetNewsByCategoryId(string categoryId);
    }
}
