using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteControls.Gateways.SiteConfiguration;
using Ninject;

namespace WebsiteControls.Analytics
{
    public partial class GoogleAnalytics : WebsiteControlBase
    {
        protected string TrackingCode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RenderTrackingCode(base.SiteConfigurationGateway.GetSiteConfiguration());
        }

        private void RenderTrackingCode(BusinessObjects.SiteConfiguration siteConfig)
        {
            trackingCodePlaceHolder.Visible = !String.IsNullOrEmpty(siteConfig.GoogleAnalyticsTrackingCode);
            TrackingCode = siteConfig.GoogleAnalyticsTrackingCode;
        }
    }
}