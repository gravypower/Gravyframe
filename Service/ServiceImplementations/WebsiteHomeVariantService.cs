using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Messages;
using Service.ServiceContracts;
using DataObjects;
using WebsiteKernel;

namespace Service.ServiceImplementations
{
    public class WebsiteHomeVariantService : Service<LoadOptions>, IWebsiteHomeVariantService
    {
        private readonly IWebsiteHomeVariantDao websiteHomeVariantDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteConfigurationService" /> class.
        /// </summary>
        /// <param name="siteConfigurationDao">The site configuration DAO.</param>
        public WebsiteHomeVariantService(IWebsiteHomeVariantDao websiteHomeVariantDao)
        {
            Guard.IsNotNull(() => websiteHomeVariantDao);

            this.websiteHomeVariantDao = websiteHomeVariantDao;
        }

        public HomeVariantResponse GetHomeVariants(HomeVariantRequest request)
        {
            var response = new HomeVariantResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            switch (request.LoadOptions.FlagLoadOptions())
            {
                //gets a list of news with a list of categories filter and date filter and limited
                case (LoadOptions.Get | LoadOptions.ObjectList):
                    response.HomeVariantList = websiteHomeVariantDao.GetHomeVariant().ToList();
                    break;


                //the combination of load options is not implemented
                default:
                    var loadOptions = Array.ConvertAll(request.LoadOptions, value => value);
                    throw new NotImplementedException(String.Format("GetHomeVariants does not implemented path for load option of {0}", String.Join(",", loadOptions)));
            }

            return response;
        }
    }
}
