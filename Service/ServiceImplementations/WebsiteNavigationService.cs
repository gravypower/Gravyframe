﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.ServiceContracts;
using Service.Messages;
using DataObjects;
using WebsiteKernel;

namespace Service.ServiceImplementations
{
    public class WebsiteNavigationService : Service<string>, IWebsiteNavigationService
    {
        private readonly IWebsiteNavigationDao websiteNavigationDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;



        public WebsiteNavigationService(IWebsiteNavigationDao websiteNavigationDao, ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => websiteNavigationDao);
            Guard.IsNotNull(() => siteConfigurationDao);

            this.websiteNavigationDao = websiteNavigationDao;
            this.siteConfigurationDao = siteConfigurationDao;
        }

        public WebsiteNavigationResponse GetWebsiteNavigation(WebsiteNavigationRequest request)
        {
            var response = new WebsiteNavigationResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            if (request.LoadOptions.Contains("MainNavigation"))
            {
                var siteConfiguration = siteConfigurationDao.GetSiteConfiguration();
                response.WhiteLabelNavigationList = websiteNavigationDao.GetNavigationItems(siteConfiguration.MainNavigationItem).ToList();
            }
            else if (request.LoadOptions.Contains("FooterNavigation"))
            {
                var siteConfiguration = siteConfigurationDao.GetSiteConfiguration();
                response.WhiteLabelNavigationList = websiteNavigationDao.GetNavigationItems(siteConfiguration.FooterNavigationItem).ToList();
            }
            else if (request.LoadOptions.Contains("SidebarNavigation"))
            {
                var siteConfiguration = siteConfigurationDao.GetSiteConfiguration();
                response.WhiteLabelNavigationList = websiteNavigationDao.GetNavigationItems(siteConfiguration.SideNavigationItem, request.SideNavigationStartItem).ToList();
            }
            else if (request.LoadOptions.Contains("NewsNavigation"))
            {
                var siteConfiguration = siteConfigurationDao.GetSiteConfiguration();
                response.WhiteLabelNavigationList = websiteNavigationDao.GetWebsiteArticleNavigation(siteConfiguration.NewsBucket).ToList();
            }
            else if (request.LoadOptions.Contains("FeaturedNavigation"))
            {
                response.WhiteLabelNavigationList = websiteNavigationDao.GetWebsiteFeaturedNavigation(request.ContentId).ToList();
            }

            return response;
        }
    }
}
