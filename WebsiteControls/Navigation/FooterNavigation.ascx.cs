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
    public partial class FooterNavigation : WebsiteControlBase
    {
        [Inject]
        public IWebsitelNavigationGateway WebsitelNavigationGateway { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var items = WebsitelNavigationGateway.GetFooterNavigation();
            if (items != null && items.Count > 0)
            {
                //bind items for the footer
                CommonNavigation.NavigationItems = items;
            }
            else
            {
                plhFooterNavigation.Visible = false;
            }
        }
    }
}