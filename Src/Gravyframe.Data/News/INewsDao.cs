using System.Collections.Generic;

namespace Gravyframe.Data.News
{
    public interface INewsDao
    {
        Models.News GetNews(string newsId);

        IEnumerable<Models.News> GetNewsByCategoryId(string categoryId);
    }
}
