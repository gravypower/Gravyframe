using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Web;
using Ninject;
using WebsiteControls.Gateways.SiteConfiguration;
using BusinessObjects;

namespace WebsiteControls
{
    public class WebsiteControlBase : UserControlBase
    {
        // <summary>
        /// Gets or sets the site configuration gateway.
        /// </summary>
        /// <value>The site configuration gateway.</value>
        [Inject]
        public ISiteConfigurationGateway SiteConfigurationGateway { get; set; }

        /// <summary>
        /// Gets the site configuration.
        /// </summary>
        /// <value>The site configuration.</value>
        protected SiteConfiguration SiteConfiguration
        {
            get
            {
                return SiteConfigurationGateway.GetSiteConfiguration();
            }
        }
    }
}