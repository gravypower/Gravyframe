using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Umbraco.Implementation
{
    public class UmbracoWebsiteNewsDao : IWebsiteNewsDao
    {
        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInBucket(string bucketId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInBucket(string bucketId, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInBucket(string bucketId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInBucket(string bucketId, DateTime from, DateTime to, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.News.WebsiteNews GetCurrentWebsiteArticleInfomationInBucket(string bucketId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInCategory(string categoryId, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInCategory(string categoryId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInCategory(string categoryId, DateTime from, DateTime to, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.News.WebsiteNews GetCurrentWebsiteArticleInfomationInCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, DateTime from, DateTime to, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.News.WebsiteNews GetCurrentWebsiteNewsInfomationInCategories(IEnumerable<string> categoryIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.News.WebsiteNews> SearchWebsiteArticle(string whiteLabelArticleName)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.News.WebsiteNews GetWebsiteArticle(string whiteLabelArticleId)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.News.WebsiteNews GetCurrentWebsiteArticle()
        {
            throw new NotImplementedException();
        }
    }
}
