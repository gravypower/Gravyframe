using System;
using System.Linq;
using Ninject;
using Ninject.Web;
using BusinessObjects;
using WebsiteControls.Gateways.SiteConfiguration;

namespace SitecoreClient.Layouts
{
    public partial class OneColumn : PageBase
    {
        /// <summary>
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

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize
        /// the page.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            //check site settings so that we can work out what to show and hide
            panMainNavigation.Visible = SiteConfiguration.ShowMainNavigation;
            panFooterNavigation.Visible = SiteConfiguration.ShowFooterNavigation;

            base.OnInit(e);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (plaSidebarNavigation.Controls.Count > 0)
            {
                sidebarNavigation.Visible = false;
            }
        }
    }
}