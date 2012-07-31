using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Sitecore.Mapper;
using BusinessObjects;
using SC = global::Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace DataObjects.Sitecore.Implementation
{
    public class SitecoreSiteConfigurationDao : ISiteConfigurationDao
    {
        private readonly ISitecoreContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreSiteConfigurationDao" /> class.
        /// </summary>
        public SitecoreSiteConfigurationDao()
        {
            context = new SitecoreContext();
        }

        /// <summary>
        /// Gets the site configuration.
        /// </summary>
        /// <returns></returns>
        public SiteConfiguration GetSiteConfiguration()
        {
            var siteItem = Utilities.Sites.GetContentStartItem();
            return GetSiteConfigurationWorker(siteItem);
        }

        public SiteConfiguration GetSiteConfiguration(string siteId)
        {
            var siteItem = SC.Context.Database.GetItem(new ID(siteId));
            return GetSiteConfigurationWorker(siteItem);
        }

        private SiteConfiguration GetSiteConfigurationWorker(Item siteItem)
        {
            var siteConfigItem = Utilities.Sites.GetConfigItem(siteItem);
            var siteConfig = context.GetItem<SiteConfiguration>(siteConfigItem.ID.Guid);

            siteConfig.SiteName = siteItem.Name;

            return siteConfig;
        }
    }
}
