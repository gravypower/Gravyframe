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
using WebsiteControls.Gateways.WebsiteContent;
using BusinessObjects.Content;

namespace UmbracoClient.masterpages
{
    public partial class mcIvorForest : UmbracoMasterPageBase
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


        [Inject]
        public IWebsiteContentGateway WhiteLabelContentGateway { get; set; }


        protected int BackgroundCount
        {
            get
            {
                int count = 0;
                if (Content.Backgrounds != null)
                {
                    count = Content.Backgrounds.Count();
                }
                return count;
            }
        }

        protected WebsiteContent Content
        {
            get
            {
                return WhiteLabelContentGateway.GetCurrentPage();
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {

            //check site settings so that we can work out what to show and hide
            panMainNavigation.Visible = SiteConfiguration.ShowMainNavigation;
            panFooterNavigation.Visible = SiteConfiguration.ShowFooterNavigation;

            rptBackground.DataSource = Content.Backgrounds;
            rptBackground.DataBind();

            base.Page_Load(sender, e);
        }
        protected override void OnPreRender(EventArgs e)
        {
            panSubMenuSpace.Visible = subMenuNav.Visible = sidebarNavigation.SubNavVisible;
            base.OnPreRender(e);
        }

        protected void rptBackground_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = (Glass.Sitecore.Mapper.FieldTypes.Image)e.Item.DataItem;
                var imgBackground = (Image)e.Item.FindControl("imgBackground");

                if ((e.Item.ItemIndex + 1) == BackgroundCount)
                {
                    imgBackground.ImageUrl = dataItem.Src;
                    imgBackground.Attributes.Add("data-count", "1");
                }
                else
                {
                    imgBackground.ImageUrl = "~/Content/Images/onePixelpng.png";
                    imgBackground.Attributes.Add("data-count", (BackgroundCount - e.Item.ItemIndex).ToString());
                }

                imgBackground.Attributes.Add("data-original", dataItem.Src);


            }
        }
    }
}