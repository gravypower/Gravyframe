using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteControls.Gateways.WebsiteNews
{
    public interface IWebsiteNewsGateway
    {
        BusinessObjects.News.WebsiteNews GetCurrentNews();
        BusinessObjects.News.WebsiteNews GetNews(object newsItemID);
        IList<BusinessObjects.News.WebsiteNews> GetAllNews();
        IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(object categoryId);
        IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(IList<object> categoryIds);

        IList<BusinessObjects.News.WebsiteNews> GetAllNews(DateTime from, DateTime to);
        IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(object categoryId, DateTime from, DateTime to);
        IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(IList<object> categoryIds, DateTime from, DateTime to);

        IList<BusinessObjects.News.WebsiteNews> GetAllNews(DateTime from, DateTime to, int offset, int number);
        IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(object categoryId, DateTime from, DateTime to, int offset, int number);
        IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(IList<object> categoryIds, DateTime from, DateTime to, int offset, int number);
    }
}
