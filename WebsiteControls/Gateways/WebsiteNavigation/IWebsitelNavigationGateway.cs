using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteControls.Gateways.WebsiteNavigation
{
    public interface IWebsitelNavigationGateway
    {
        IList<BusinessObjects.Navigation.WebsiteNavigation> GetMainNavigation();

        IList<BusinessObjects.Navigation.WebsiteNavigation> GetFooterNavigation();

        IList<BusinessObjects.Navigation.WebsiteNavigation> GetSidebarNavigation(object itemID);

        IList<BusinessObjects.Navigation.WebsiteNavigation> GetNewsNavigation();

        IList<BusinessObjects.Navigation.WebsiteNavigation> GetEventNavigation();

        IList<BusinessObjects.Navigation.WebsiteNavigation> GetFeaturedNavigation();
    }
}
