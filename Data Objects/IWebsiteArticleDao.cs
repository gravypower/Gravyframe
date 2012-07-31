using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public interface IWebsiteArticleDao<T>
    {
        IEnumerable<T> GetWebsiteArticleInBucket(string bucketId);
        IEnumerable<T> GetWebsiteArticleInBucket(string bucketId, int offset, int number);
        IEnumerable<T> GetWebsiteArticleInBucket(string bucketId, DateTime from, DateTime to);
        IEnumerable<T> GetWebsiteArticleInBucket(string bucketId, DateTime from, DateTime to, int offset, int number);
        T GetCurrentWebsiteArticleInfomationInBucket(string bucketId);

        IEnumerable<T> GetWebsiteArticleInCategory(string categoryId);
        IEnumerable<T> GetWebsiteArticleInCategory(string categoryId, int offset, int number);
        IEnumerable<T> GetWebsiteArticleInCategory(string categoryId, DateTime from, DateTime to);
        IEnumerable<T> GetWebsiteArticleInCategory(string categoryId, DateTime from, DateTime to, int offset, int number);
        T GetCurrentWebsiteArticleInfomationInCategory(string categoryId);

        IEnumerable<T> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds);
        IEnumerable<T> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, int offset, int number);
        IEnumerable<T> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, DateTime from, DateTime to);
        IEnumerable<T> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, DateTime from, DateTime to, int offset, int number);
        T GetCurrentWebsiteNewsInfomationInCategories(IEnumerable<string> categoryIds);

        IEnumerable<T> SearchWebsiteArticle(string whiteLabelArticleName);
        T GetWebsiteArticle(string whiteLabelArticleId);
        T GetCurrentWebsiteArticle();
    }
}
