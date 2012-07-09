using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Configuration;
using Sitecore.Sites;
using Sitecore.Data;

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
    }
}
