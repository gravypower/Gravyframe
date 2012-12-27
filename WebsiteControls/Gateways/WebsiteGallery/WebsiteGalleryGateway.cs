using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.ServiceContracts;
using WebsiteKernel;
using Service.Messages;

namespace WebsiteControls.Gateways.WebsiteGallery
{
    public class WebsiteGalleryGateway : GatewayBase<LoadOptions>, IWebsiteGalleryGateway
    {
        private readonly IWebsiteGalleryService websiteGalleryService;

        public WebsiteGalleryGateway(
            IWebsiteGalleryService websiteGalleryService, 
            IClientTagService clientTagService, 
            IItemIDService itemIDService)
            :base(itemIDService, clientTagService)
        {
            //make sure the injection he worked.
            Guard.IsNotNull(() => websiteGalleryService);

            //wire up the injected service
            this.websiteGalleryService = websiteGalleryService;
        }

        private WebsiteGalleryResponse GetWebsitetGallery(LoadOptions[] loadOptions = null, WebsiteGalleryRequest request = null)
        {
            //check that we have not passed in a request
            if (request == null)
            {
                //create a new request
                request = new WebsiteGalleryRequest();
            }

            if (loadOptions != null)
            {
                //set the load options form what was passed in
                request.LoadOptions = loadOptions;
            }

            //TODO: get this from the config Website.ClientTag
            request.ClientTag = clientTagService.GetClientTag();

            //make the call
            var response = websiteGalleryService.GetWebsiteGallery(request);

            //make sure all is well
            Correlate(request, response);

            //return it to 
            return response;
        }

        public IList<BusinessObjects.Gallery.GalleryImage> GetCurrentGallery()
        {
            var request = new WebsiteGalleryRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectList, LoadOptions.Current };
            return GetWebsitetGallery(null, request).GalleryImagetList;
        }

        public IList<BusinessObjects.Gallery.GalleryImage> GetGallery(object itemID)
        {
            var request = new WebsiteGalleryRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectList};
            request.GalleryId = itemID.ToString();
            return GetWebsitetGallery(null, request).GalleryImagetList;
        }
    }
}