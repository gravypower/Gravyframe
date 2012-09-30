using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.ServiceContracts;
using DataObjects;
using WebsiteKernel;
using Service.Messages;

namespace Service.ServiceImplementations
{
    public class WebsiteContentService : Service<string>, IWebsiteContentService
    {
        private readonly IWebsiteContentDao websiteContentDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;
        
         /// <summary>
        /// Initializes a new instance of the <see cref="WhiteLabelContentService" /> class.
        /// </summary>
        /// <param name="whiteLabelContentDao">The white label content DAO.</param>
        /// <param name="siteConfigurationDao">The site configuration DAO.</param>
        public WebsiteContentService(IWebsiteContentDao websiteContentDao, ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => websiteContentDao);
            Guard.IsNotNull(() => siteConfigurationDao);

            this.websiteContentDao = websiteContentDao;
            this.siteConfigurationDao = siteConfigurationDao;
        }


        public Messages.WebsiteContentResponse GetWebsiteContent(Messages.WebsiteContentRequest request)
        {
            var response = new WebsiteContentResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            if (request.LoadOptions.Contains("CurrentPage"))
            {
                response.WebsiteContent = websiteContentDao.GetCurrentWebsiteContent();
            }
            else if (request.LoadOptions.Contains("CurrentPageChildren"))
            {
                response.WebsiteContentList = websiteContentDao.GetCurrentWebsiteContentChildren();
            }

            return response;
        }
    }
}
