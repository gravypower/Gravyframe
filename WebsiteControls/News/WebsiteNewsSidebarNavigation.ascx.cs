using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using WebsiteControls.Gateways.WebsiteNavigation;

namespace WebsiteControls.News
{
    public partial class WhiteLabelNewsSidebarNavigation : WebsiteControlBase
    {
        [Inject]
        public IWebsitelNavigationGateway WebsitelNavigationGateway { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var items = WebsitelNavigationGateway.GetNewsNavigation();
            if (items != null && items.Count > 0)
            {
                //bind items for the main navigation
                CommonNavigation.NavigationItems = items;
            }
            else
            {
                plhNavSub.Visible = false;
            }
        }
    }
}