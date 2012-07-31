using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.ServiceContracts;
using WebsiteKernel;
using Service.Messages;

namespace WebsiteControls.Gateways.SiteConfiguration
{
    public class SiteConfigurationGateway : GatewayBase<string>, ISiteConfigurationGateway
    {
        private readonly ISiteConfigurationService siteConfigurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteConfigurationGateway" /> class.
        /// </summary>
        /// <param name="siteConfigurationService">The site configuration service.</param>
        public SiteConfigurationGateway(
            ISiteConfigurationService siteConfigurationService, 
            IClientTagService clientTagService,
            IItemIDService itemIDService)
            : base(itemIDService, clientTagService)
        {
            //make sure the injection he worked.
            Guard.IsNotNull(() => siteConfigurationService);
            Guard.IsNotNull(() => clientTagService);

            //wire up the injected service
            this.siteConfigurationService = siteConfigurationService;
        }



        /// <summary>
        /// Gets the configuration for the context site.
        /// </summary>
        /// <returns>a SiteConfiguration object</returns>
        public BusinessObjects.SiteConfiguration GetSiteConfiguration()
        {
            BusinessObjects.SiteConfiguration returnSiteConfiguration = null;

            //check to see that we have not already fetched the SiteConfiguration this request.
            if (!HttpContext.Current.Items.Contains("SiteConfiguration"))
            {
                //create a new request
                var request = new SiteConfigurationRequest();

                request.ClientTag = clientTagService.GetClientTag();

                //make the request
                var response = siteConfigurationService.GetSiteConfiguration(request);

                Correlate(request, response);

                returnSiteConfiguration = response.SiteConfiguration;

                //add the SiteConfiguration to the context items so it can be reused if needed
                HttpContext.Current.Items.Add("SiteConfiguration", returnSiteConfiguration);
            }
            else
            {
                // the SiteConfiguration was in the context items so just use that
                returnSiteConfiguration = HttpContext.Current.Items["SiteConfiguration"] as BusinessObjects.SiteConfiguration;
            }

            return returnSiteConfiguration;
        }
    }
}