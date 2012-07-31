using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Messages;
using Service.ServiceContracts;
using WebsiteKernel;
using DataObjects;

namespace Service.ServiceImplementations
{
    public class WebsiteEventService : Service<LoadOptions>, IWebsiteEventService
    {
        private readonly IWebsiteEventDao websiteEventDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;

        public WebsiteEventService(IWebsiteEventDao websiteEventDao, ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => websiteEventDao);
            Guard.IsNotNull(() => siteConfigurationDao);

            this.siteConfigurationDao = siteConfigurationDao;
            this.websiteEventDao = websiteEventDao;

        }

        public WebsiteEventResponse GetWebsiteEvent(WebsiteEventRequest request)
        {
            var response = new WebsiteEventResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            var siteConfiguration = siteConfigurationDao.GetSiteConfiguration();


            switch (request.LoadOptions.FlagLoadOptions())
            {
                #region Single Event
                //Gets the current Event
                case (LoadOptions.Get | LoadOptions.Current | LoadOptions.ObjectSingle):
                    response.WebsiteEvent = websiteEventDao.GetCurrentWebsiteArticle();
                    break;

                //Gets Event by ID
                case (LoadOptions.Get | LoadOptions.ObjectSingle):
                    response.WebsiteEvent = websiteEventDao.GetWebsiteArticle(request.EventId);
                    break;

                #endregion

                #region Bucket Event
                //gets a list of Event
                case (LoadOptions.Get | LoadOptions.ObjectList):
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInBucket(siteConfiguration.EventBucket).ToList();
                    break;

                //gets a list of Event and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.LimitResult:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInBucket(siteConfiguration.EventBucket, request.From, request.To).ToList();
                    break;

                //gets a list of Event filtered by date
                case (LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.DateFilter):
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInBucket(siteConfiguration.EventBucket, request.From, request.To).ToList();
                    break;

                //gets a list of Event filtered by date and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.DateFilter | LoadOptions.LimitResult:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInBucket(siteConfiguration.EventBucket, request.From, request.To, request.Offset, request.Number).ToList();
                    break;
                #endregion

                #region Category Event

                //gets a list of Event with a category filter
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Category:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInCategory(request.CategoryId).ToList();
                    break;

                //gets a list of Event with a category filter and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Category | LoadOptions.LimitResult:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInCategory(request.CategoryId, request.Offset, request.Number).ToList();
                    break;

                //gets a list of Event with a category filter and date filter
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Category | LoadOptions.DateFilter:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInCategory(request.CategoryId, request.From, request.To).ToList();
                    break;

                //gets a list of Event with a category filter and date filter and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Category | LoadOptions.DateFilter | LoadOptions.LimitResult:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInCategory(request.CategoryId, request.From, request.To, request.Offset, request.Number).ToList();
                    break;
                #endregion

                #region List of Categories Event

                //gets a list of Event with a list of categories filter
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.CategoryList:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInCategories(request.CategoryIds).ToList();
                    break;

                //gets a list of Event with a list of categories filter and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.CategoryList | LoadOptions.LimitResult:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInCategories(request.CategoryIds, request.Offset, request.Number).ToList();
                    break;

                //gets a list of Event with a list of categories filter and date filter
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.CategoryList | LoadOptions.DateFilter:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInCategories(request.CategoryIds, request.From, request.To).ToList();
                    break;

                //gets a list of Event with a list of categories filter and date filter and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.CategoryList | LoadOptions.DateFilter | LoadOptions.LimitResult:
                    response.WebsiteEventList = websiteEventDao.GetWebsiteArticleInCategories(request.CategoryIds, request.From, request.To, request.Offset, request.Number).ToList();
                    break;

                #endregion

                //the combination of load options is not implemented
                default:
                    var loadOptions = Array.ConvertAll(request.LoadOptions, value => value);
                    throw new NotImplementedException(String.Format("GetWebsiteEventContent does not implemented path for load option of {0}", String.Join(",", loadOptions)));
            }

            return response;
        }
    }
}
