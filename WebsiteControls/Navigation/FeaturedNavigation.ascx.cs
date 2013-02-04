using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using WebsiteControls.Gateways.WebsiteNavigation;
using BusinessObjects.Navigation;

namespace WebsiteControls.Navigation
{
    public partial class FeaturedNavigation : WebsiteControlBase
    {
        [Inject]
        public IWebsitelNavigationGateway WebsitelNavigationGateway { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var navItems = WebsitelNavigationGateway.GetFeaturedNavigation();
                if (navItems.Count > 0)
                {
                    rptFeaturedNavigation.DataSource = navItems;
                    rptFeaturedNavigation.DataBind();
                }
                else
                {
                    plhNavigation.Visible = false;
                }
            }
            catch (Exception ex)
            {

                plhNavigation.Visible = false;
            }
            
        }

        protected void rptFeaturedNavigation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var navDataItem = (WebsiteNavigation)e.Item.DataItem;
                if (navDataItem!= null && navDataItem.FeaturedImage != null)
                {
                    var hypFeaturedNavigationItem = (HyperLink)e.Item.FindControl("hypFeaturedNavigationItem");
                    var panVisibleImage = (Panel)e.Item.FindControl("panVisibleImage");
                    var panAppearingImage = (Panel)e.Item.FindControl("panAppearingImage");

                    var litTitle = (Literal)e.Item.FindControl("litTitle");

                    panVisibleImage.Style.Add("background-image", navDataItem.FeaturedImage.Src);
                    panAppearingImage.Style.Add("background-image", navDataItem.FeaturedImage.Src);

                    hypFeaturedNavigationItem.NavigateUrl = navDataItem.NavigateUrl;
                    litTitle.Text = navDataItem.Title;
                }

            }
        }
    }
}