using System;
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
            try
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
            catch (Exception)
            {
                plhFooterNavigation.Visible = false;
            }
            
        }
    }
}