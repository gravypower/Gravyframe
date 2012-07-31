using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using WebsiteControls.Gateways.WebsiteNavigation;

namespace WebsiteControls.Navigation
{
    public partial class SidebarNavigation : WebsiteControlBase
    {
        [Inject]
        public IWebsitelNavigationGateway WebsitelNavigationGateway { get; set; }

        [Inject]
        public IItemIDService ItemIDService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var items = WebsitelNavigationGateway.GetSidebarNavigation(ItemIDService.GetContextItemId());
            if (items != null && items.Count > 0)
            {
                //bind items for the side navigation
                CommonNavigation.NavigationItems = items;
            }
            else
            {
                plhNavSub.Visible = false;
            }
        }
    }
}