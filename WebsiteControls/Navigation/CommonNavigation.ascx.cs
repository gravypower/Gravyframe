using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects.Navigation;
using System.Web.UI.HtmlControls;

namespace WebsiteControls.Navigation
{
    public partial class CommonNavigation : WebsiteControlBase
    {
        /// <summary>
        /// Gets or sets the navigation items.
        /// </summary>
        /// <value>The navigation items.</value>
        public IList<WebsiteNavigation> NavigationItems { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (NavigationItems != null)
            {
                //binds items to the repeater
                rptMianNavigation.DataSource = NavigationItems;
                rptMianNavigation.DataBind();
            }
        }


        /// <summary>
        /// RPTs the mian navigation item data bound.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs" /> instance containing the event data.</param>
        protected void RptMianNavigationItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //cast the data item to WhiteLabelContent
                var navDataItem = (WebsiteNavigation)e.Item.DataItem;

                //find the li control
                var liNavItem = (HtmlGenericControl)e.Item.FindControl("liNavItem");

                //find the hyper link 
                var hypNavItem = (HyperLink)e.Item.FindControl("hypNavItem");

                //set the class of the li
                liNavItem.Attributes.Add("class", navDataItem.ItemClass);

                //if there is an icon
                if (navDataItem.Icon != null && navDataItem.Icon.MediaId != Guid.Empty)
                {
                    //get the image tag
                    var imgNavItem = (Image)e.Item.FindControl("imgNavItem");

                    //map the image to the image tag
                    LayoutUtils.MapImage(imgNavItem, navDataItem.Icon);
                }
                else
                {
                    //otherwise just display the text
                    hypNavItem.Text = String.IsNullOrEmpty(navDataItem.MenuTitle) ? navDataItem.Title : navDataItem.MenuTitle;
                }

                //is the a redirected item?
                if (navDataItem.Redirect != null)
                {
                    //if it is then map the link to the hyper link tag
                    LayoutUtils.MapLink(hypNavItem, navDataItem.Redirect);
                }
                else
                {
                    //otherwise just use the item url
                    hypNavItem.NavigateUrl = navDataItem.NavigateUrl;
                }

                //set the hyperlink class
                hypNavItem.CssClass = navDataItem.ItemClass;
            }
        }
    }
}