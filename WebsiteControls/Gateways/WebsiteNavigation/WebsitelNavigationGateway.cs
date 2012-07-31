using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.ServiceContracts;
using WebsiteKernel;

namespace WebsiteControls.Gateways.WebsiteNavigation
{
    public class WebsitelNavigationGateway : GatewayBase<string>, IWebsitelNavigationGateway
    {

        private readonly IWebsiteNavigationService websiteNavigationService;


        public WebsitelNavigationGateway(
            IWebsiteNavigationService websiteNavigationService, 
            IClientTagService clientTagService, 
            IItemIDService itemIDService)
            :base(itemIDService, clientTagService)
        {
            //make sure the injection he worked.
            Guard.IsNotNull(() => websiteNavigationService);

            //wire up the injected service
            this.websiteNavigationService = websiteNavigationService;
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetMainNavigation()
        {
            throw new NotImplementedException();
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetFooterNavigation()
        {
            throw new NotImplementedException();
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetSidebarNavigation(object itemID)
        {
            throw new NotImplementedException();
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetNewsNavigation()
        {
            throw new NotImplementedException();
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetEventNavigation()
        {
            throw new NotImplementedException();
        }
    }
}