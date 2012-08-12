using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.ServiceContracts;
using WebsiteKernel;
using Service.Messages;

namespace WebsiteControls.Gateways.WebsiteContent
{
    public class WebsiteHomeVariantGateway : GatewayBase<LoadOptions>, IWebsiteHomeVariantGateway
    {

        private readonly IWebsiteHomeVariantService websiteHomeVariantService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WhiteLabelContentGateway" /> class.
        /// </summary>
        /// <param name="whiteLabelContentService">The white label content service.</param>
        public WebsiteHomeVariantGateway(
            IWebsiteHomeVariantService websiteHomeVariantService,
            IClientTagService clientTagService,
            IItemIDService itemIDService)
            : base(itemIDService, clientTagService)
        {
            //make sure the injection he worked.
            Guard.IsNotNull(() => websiteHomeVariantService);

            //wire up the injected service
            this.websiteHomeVariantService = websiteHomeVariantService;
        }        

        public IList<BusinessObjects.Content.HomeVariant> GetHomeVariants()
        {
            IList<BusinessObjects.Content.HomeVariant> retrunList;
            //check that context item for the current page so we don't have to fetch it again
            if (!HttpContext.Current.Items.Contains("GetHomeVariants"))
            {
                var request = new HomeVariantRequest();
                request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectList };
                retrunList = GetHomeVariants(null, request).HomeVariantList;

                //save it in the context items 
                HttpContext.Current.Items.Add("GetHomeVariants", retrunList);
            }
            else
            {
                //it was there so lets just reuse it
                retrunList = HttpContext.Current.Items["GetHomeVariants"] as IList<BusinessObjects.Content.HomeVariant>;
            }

            return retrunList;
          
        }

        private HomeVariantResponse GetHomeVariants(LoadOptions[] loadOptions = null, HomeVariantRequest request = null)
        {
            //check that we have not passed in a request
            if (request == null)
            {
                //create a new request
                request = new HomeVariantRequest();
            }

            if (loadOptions != null)
            {
                //set the load options form what was passed in
                request.LoadOptions = loadOptions;
            }

            request.ClientTag = clientTagService.GetClientTag();

            //make the call
            var response = websiteHomeVariantService.GetHomeVariants(request);

            //make sure all is well
            Correlate(request, response);

            //return it to 
            return response;
        }
    }
}