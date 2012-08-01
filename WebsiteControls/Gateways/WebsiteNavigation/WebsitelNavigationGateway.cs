using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.ServiceContracts;
using WebsiteKernel;
using Service.Messages;

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
            //get the the main navigation
            return GetWebsiteNavigation(new[] { "MainNavigation" }).WhiteLabelNavigationList;
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetFooterNavigation()
        {
            // get the footer navigation
            return GetWebsiteNavigation(new[] { "FooterNavigation" }).WhiteLabelNavigationList;
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetSidebarNavigation(object itemID)
        {
            //create a new request as we are adding some extra information
            var request = new WebsiteNavigationRequest();

            //set the start item from what was passed in
            request.SideNavigationStartItem = itemIDService.GetItemId(itemID);

            //get the side bar navigation
            return GetWebsiteNavigation(new[] { "SidebarNavigation" }, request).WhiteLabelNavigationList;
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetNewsNavigation()
        {
            var request = new WebsiteNavigationRequest();
            request.LoadOptions = new[] { "NewsNavigation" };
            return GetWebsiteNavigation(null, request).WhiteLabelNavigationList;
        }

        public IList<BusinessObjects.Navigation.WebsiteNavigation> GetEventNavigation()
        {
            throw new NotImplementedException();
        }


        private WebsiteNavigationResponse GetWebsiteNavigation(string[] loadOptions = null, WebsiteNavigationRequest request = null)
        {
            //check that we have not passed in a request
            if (request == null)
            {
                //create a new request
                request = new WebsiteNavigationRequest();
            }

            if (loadOptions != null)
            {
                //set the load options form what was passed in
                request.LoadOptions = loadOptions;
            }

            //TODO: get this from the config Website.ClientTag
            request.ClientTag = clientTagService.GetClientTag();

            //make the call
            var response = websiteNavigationService.GetWebsiteNavigation(request);

            //make sure all is well
            Correlate(request, response);

            //return it to 
            return response;
        }
    }
}