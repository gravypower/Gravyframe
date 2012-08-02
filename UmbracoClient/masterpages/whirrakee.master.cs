using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteControls.Gateways.SiteConfiguration;
using Ninject;
using BusinessObjects;
using Ninject.Web;

namespace UmbracoClient.masterpages
{
    public partial class whirrakee : MasterPageBase
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


        protected void Page_Load(object sender, EventArgs e)
        {
            //check site settings so that we can work out what to show and hide
            panMainNavigation.Visible = SiteConfiguration.ShowMainNavigation;
            panFooterNavigation.Visible = SiteConfiguration.ShowFooterNavigation;
        }
    }
}