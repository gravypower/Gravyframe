using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.ServiceContracts;
using WebsiteKernel;
using DataObjects;
using Service.Messages;

namespace Service.ServiceImplementations
{
    public class SiteConfigurationService :Service<string>, ISiteConfigurationService
    {
        private readonly ISiteConfigurationDao siteConfigurationDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteConfigurationService" /> class.
        /// </summary>
        /// <param name="siteConfigurationDao">The site configuration DAO.</param>
        public SiteConfigurationService(ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => siteConfigurationDao);

            this.siteConfigurationDao = siteConfigurationDao;
        }

        public SiteConfigurationResponse GetSiteConfiguration(Messages.SiteConfigurationRequest request)
        {
            var response = new SiteConfigurationResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            if (request.LoadOptions != null && request.LoadOptions.Contains("BySiteID"))
            {
                response.SiteConfiguration = siteConfigurationDao.GetSiteConfiguration(request.SiteId);
            }
            else
            {
                response.SiteConfiguration = siteConfigurationDao.GetSiteConfiguration();
            }

            return response;
        }

    }
}
