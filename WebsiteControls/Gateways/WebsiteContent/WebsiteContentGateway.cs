using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.ServiceContracts;
using WebsiteKernel;
using Service.Messages;

namespace WebsiteControls.Gateways.WebsiteContent
{
    public class WebsiteContentGateway : GatewayBase<string>, IWebsiteContentGateway
    {

        private readonly IWebsiteContentService websiteContentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WhiteLabelContentGateway" /> class.
        /// </summary>
        /// <param name="whiteLabelContentService">The white label content service.</param>
        public WebsiteContentGateway(
            IWebsiteContentService websiteContentService,
            IClientTagService clientTagService,
            IItemIDService itemIDService)
            : base(itemIDService, clientTagService)
        {
            //make sure the injection he worked.
            Guard.IsNotNull(() => websiteContentService);

            //wire up the injected service
            this.websiteContentService = websiteContentService;
        }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        /// <returns>the WebsiteContent representing the current page</returns>
        public BusinessObjects.Content.WebsiteContent GetCurrentPage()
        {
            BusinessObjects.Content.WebsiteContent returnWhiteLabelContent = null;

            //check that context item for the current page so we don't have to fetch it again
            if (!HttpContext.Current.Items.Contains("CurrentPage"))
            {
                //its not there get it form the service
                returnWhiteLabelContent = GetWhiteLabelContent(new[] { "CurrentPage" }).WebsiteContent;

                //save it in the context items 
                HttpContext.Current.Items.Add("CurrentPage", returnWhiteLabelContent);
            }
            else
            {
                //it was there so lets just reuse it
                returnWhiteLabelContent = HttpContext.Current.Items["CurrentPage"] as BusinessObjects.Content.WebsiteContent;
            }

            return returnWhiteLabelContent;
        }


        public IList<BusinessObjects.Gallery.GalleryImage> GetImageGallery()
        {
            return GetWhiteLabelContent(new[] { "Gallery" }).GalleryImageList;
            
        }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        /// <returns>the WebsiteContent representing the current page</returns>
        public BusinessObjects.Content.WebsiteContent CurrentPageChildren()
        {
            BusinessObjects.Content.WebsiteContent returnWhiteLabelContent = null;

            //check that context item for the current page so we don't have to fetch it again
            if (!HttpContext.Current.Items.Contains("CurrentPageChildren"))
            {
                //its not there get it form the service
                returnWhiteLabelContent = GetWhiteLabelContent(new[] { "CurrentPageChildren" }).WebsiteContent;

                //save it in the context items 
                HttpContext.Current.Items.Add("CurrentPageChildren", returnWhiteLabelContent);
            }
            else
            {
                //it was there so lets just reuse it
                returnWhiteLabelContent = HttpContext.Current.Items["CurrentPageChildren"] as BusinessObjects.Content.WebsiteContent;
            }

            return returnWhiteLabelContent;
        }


        /// <summary>
        /// Gets the content of the white label.
        /// </summary>
        /// <param name="loadOptions">The load options.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private WebsiteContentResponse GetWhiteLabelContent(string[] loadOptions, WebsiteContentRequest request = null)
        {
            //check that we have not passed in a request
            if (request == null)
            {
                //create a new request
                request = new WebsiteContentRequest();
            }

            //set the load options form what was passed in
            request.LoadOptions = loadOptions;

            //TODO: get this from the config Website.ClientTag
            request.ClientTag = clientTagService.GetClientTag();

            //make the call
            var response = websiteContentService.GetWebsiteContent(request);

            //make sure all is well
            Correlate(request, response);

            //return it to 
            return response;
        }
    }
}