using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Umbraco.Implementation
{
    public class UmbracoWebsiteEventDao : IWebsiteEventDao
    {
        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInBucket(string bucketId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInBucket(string bucketId, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInBucket(string bucketId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInBucket(string bucketId, DateTime from, DateTime to, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.Event.WebsiteEvent GetCurrentWebsiteArticleInfomationInBucket(string bucketId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInCategory(string categoryId, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInCategory(string categoryId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInCategory(string categoryId, DateTime from, DateTime to, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.Event.WebsiteEvent GetCurrentWebsiteArticleInfomationInCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, DateTime from, DateTime to, int offset, int number)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.Event.WebsiteEvent GetCurrentWebsiteNewsInfomationInCategories(IEnumerable<string> categoryIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects.Event.WebsiteEvent> SearchWebsiteArticle(string whiteLabelArticleName)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.Event.WebsiteEvent GetWebsiteArticle(string whiteLabelArticleId)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.Event.WebsiteEvent GetCurrentWebsiteArticle()
        {
            throw new NotImplementedException();
        }
    }
}
