using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Configuration;
using Sitecore.Sites;
using Sitecore.Data;
using Sitecore.Data.Items;
using SC = global::Sitecore;

namespace DataObjects.Sitecore.Utilities
{
    public class Sites
    {
        private static SiteContext _siteContext = null;

        /// <summary>
        /// Gets the site context.
        /// </summary>
        public static SiteContext SiteContext
        {
            get
            {
                if (_siteContext == null)
                {
                    //TODO:need to be able to change this
                    _siteContext = Factory.GetSite("website");
                }
                return _siteContext;
            }
        }


        public static Item GetContentStartItem()
        {
            //get the start item for the current site
            var contentStartItem = SC.Context.Database.GetItem(SC.Context.Site.ContentStartPath);
            return contentStartItem;
        }
        public static Item GetHomeItem()
        {
            return GetContentStartItem().Axes.GetChild("Home");
        }

        public static Item GetConfigItem()
        {
            return GetConfigItem(GetContentStartItem());
        }

        public static Item GetConfigItem(Item siteItem)
        {
            return siteItem.Axes.GetChild("Configuration");
        }
    }
}
