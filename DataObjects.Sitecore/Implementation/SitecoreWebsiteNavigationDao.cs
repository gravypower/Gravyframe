using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Data;
using WebsiteKernel;
using BusinessObjects;
using SC = global::Sitecore;
using System.Globalization;
using BusinessObjects.Navigation;

namespace DataObjects.Sitecore.Implementation
{
    public class SitecoreWebsiteNavigationDao : SitecoreDao, IWebsiteNavigationDao
    {

        private readonly ISiteConfigurationDao siteConfigurationDao;

        private SiteConfiguration siteconfig;
        protected SiteConfiguration Siteconfig
        {
            get
            {
                if (siteconfig == null)
                {
                    siteconfig = siteConfigurationDao.GetSiteConfiguration();
                }
                return siteconfig;
            }
        }

        public SitecoreWebsiteNavigationDao(ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => siteConfigurationDao);

            this.siteConfigurationDao = siteConfigurationDao;
        }

        public IEnumerable<WebsiteNavigation> GetNavigationItems(string navigationId)
        {
            return GetNavigationItemsWorker(navigationId, Utilities.Sites.GetHomeItem());
        }

        public IEnumerable<WebsiteNavigation> GetNavigationItems(string navigationId, string navigationStartItemId)
        {
            var navigationStartItem = SC.Context.Database.GetItem(new ID(navigationStartItemId));
            return GetNavigationItemsWorker(navigationId, navigationStartItem);
        }

        public IEnumerable<WebsiteNavigation> GetWebsiteArticleNavigation(string bucketId)
        {
            var newsBucket = SC.Context.Database.GetItem(new ID(Siteconfig.NewsBucket));

            var newsNavigation = new List<WebsiteNavigation>();
            foreach (Item item in newsBucket.Children)
            {
                if (item.Name != "1")
                {
                    foreach (Item childItem in item.Children)
                    {
                        int monthNumber;
                        if (int.TryParse(childItem.Name, out monthNumber))
                        {
                            newsNavigation.Add
                                (
                                    new WebsiteNavigation
                                    {
                                        Title = String.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber), item.Name),
                                        NavigateUrl = String.Format("{0}/{1}/{2}", Siteconfig.DefaultNewsListing.Url, item.Name, childItem.Name)
                                    }
                                );
                        }
                    }
                }
            }


            return newsNavigation;
        }


        /// <summary>
        /// Gets the navigation items worker.
        /// </summary>
        /// <param name="navigationId">The navigation id.</param>
        /// <param name="navigationStartItem">The navigation start item.</param>
        /// <returns></returns>
        private IEnumerable<WebsiteNavigation> GetNavigationItemsWorker(string navigationId, Item navigationStartItem)
        {
            var returnWhiteLabelContentList = new List<WebsiteNavigation>();
            var startItem = navigationStartItem;

            //if this is not the the navigation for the main nav and the start item has the location in it that we are looking for then use its parent
            if (Siteconfig.MainNavigationItem != navigationId && navigationStartItem["Location"].Contains(navigationId))
            {
                startItem = navigationStartItem.Parent;
            }

            //iterate though the children that have the navigationId added to the Location Tree List Field
            foreach (var item in startItem.Children.Where(item => item["Location"].Contains(navigationId)))
            {
                returnWhiteLabelContentList.Add(context.GetItem<WebsiteNavigation>(item.ID.Guid));
            }

            return returnWhiteLabelContentList;
        }


        public IEnumerable<WebsiteNavigation> GetWebsiteFeaturedNavigation(string contentId)
        {
            throw new NotImplementedException();
        }
    }
}
