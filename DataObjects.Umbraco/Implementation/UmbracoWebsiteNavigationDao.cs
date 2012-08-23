using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.interfaces;
using BusinessObjects.Navigation;
using BusinessObjects;
using WebsiteKernel;
using umbraco.NodeFactory;

namespace DataObjects.Umbraco.Implementation
{
    public class UmbracoWebsiteNavigationDao : IWebsiteNavigationDao
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

        public UmbracoWebsiteNavigationDao(ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => siteConfigurationDao);

            this.siteConfigurationDao = siteConfigurationDao;
        }

        public IEnumerable<BusinessObjects.Navigation.WebsiteNavigation> GetNavigationItems(string navigationId)
        {
            return GetNavigationItemsWorker(navigationId, Utilities.Sites.GetHomeItem());
        }

        public IEnumerable<BusinessObjects.Navigation.WebsiteNavigation> GetNavigationItems(string navigationId, string navigationStartItemID)
        {
            var navigationStartItem = new Node(int.Parse(navigationStartItemID));
            return GetNavigationItemsWorker(navigationId, navigationStartItem);
        }

        public IEnumerable<BusinessObjects.Navigation.WebsiteNavigation> GetWebsiteArticleNavigation(string bucketId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets the navigation items worker.
        /// </summary>
        /// <param name="navigationId">The navigation id.</param>
        /// <param name="navigationStartItem">The navigation start item.</param>
        /// <returns></returns>
        private IEnumerable<WebsiteNavigation> GetNavigationItemsWorker(string navigationId, INode navigationStartItem)
        {
            var returnWhiteLabelContentList = new List<WebsiteNavigation>();
            var startItem = navigationStartItem;

            //if this is not the the navigation for the main nav and the start item has the location in it that we are looking for then use its parent
            if (Siteconfig.MainNavigationItem != navigationId && navigationStartItem.GetProperty("location").Value.Contains(navigationId))
            {
                startItem = navigationStartItem.Parent;
            }

            //iterate though the children that have the navigationId added to the Location Tree List Field
            foreach (var item in startItem.ChildrenAsList.Where(item => item.GetProperty("location").Value.Contains(navigationId)))
            {
               returnWhiteLabelContentList.Add(ModelMapper.Mapper.MapWebsiteNavigation(item));
            }

            return returnWhiteLabelContentList;
        }


        public IEnumerable<WebsiteNavigation> GetWebsiteFeaturedNavigation(string contentId)
        {
            var returnWhiteLabelContentList = new List<WebsiteNavigation>();
            var content = new Node(int.Parse(contentId));

            var featuredNavigation = content.GetProperty("featuredNavigation").Value;
            
            var featuredNavigationItems = featuredNavigation.Split(',');

            foreach (var item in featuredNavigationItems)
            {
                var node = new Node(int.Parse(item));
                returnWhiteLabelContentList.Add(ModelMapper.Mapper.MapWebsiteNavigation(node));
            }

            return returnWhiteLabelContentList;
        }
    }
}
