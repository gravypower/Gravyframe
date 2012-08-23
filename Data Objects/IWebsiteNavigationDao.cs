using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Navigation;

namespace DataObjects
{
    public interface IWebsiteNavigationDao
    {
        IEnumerable<WebsiteNavigation> GetNavigationItems(string navigationId);
        IEnumerable<WebsiteNavigation> GetNavigationItems(string navigationId, string navigationStartItemID);
        IEnumerable<WebsiteNavigation> GetWebsiteArticleNavigation(string bucketId);
        IEnumerable<WebsiteNavigation> GetWebsiteFeaturedNavigation(string contentId);
    }
}
