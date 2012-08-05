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
using WebsiteKernel.Umbraco;

namespace UmbracoClient.masterpages
{
    public partial class whirrakee : UmbracoMasterPageBase
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


        protected override void Page_Load(object sender, EventArgs e)
        {
            //check site settings so that we can work out what to show and hide
            panMainNavigation.Visible = SiteConfiguration.ShowMainNavigation;
            panFooterNavigation.Visible = SiteConfiguration.ShowFooterNavigation;

            base.Page_Load(sender, e);
        }
        protected override void OnPreRender(EventArgs e)
        {
            panSubMenuSpace.Visible = subMenuNav.Visible = sidebarNavigation.SubNavVisible;
            base.OnPreRender(e);
        }
    }
}