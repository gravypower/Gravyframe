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
    public class WebsiteNewsService : Service<LoadOptions>, IWebsiteNewsService
    {
        private readonly IWebsiteNewsDao websiteNewsDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;

        public WebsiteNewsService(IWebsiteNewsDao websiteNewsDao, ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => websiteNewsDao);
            Guard.IsNotNull(() => siteConfigurationDao);

            this.siteConfigurationDao = siteConfigurationDao;
            this.websiteNewsDao = websiteNewsDao;

        }

        public WebsiteNewsResponse GetWebsiteNews(WebsiteNewsRequest request)
        {
            var response = new WebsiteNewsResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            var siteConfiguration = siteConfigurationDao.GetSiteConfiguration();


            switch (request.LoadOptions.FlagLoadOptions())
            {
                #region Single news
                //Gets the current news
                case (LoadOptions.Get | LoadOptions.Current | LoadOptions.ObjectSingle):
                    response.WebsiteNews = websiteNewsDao.GetCurrentWebsiteArticle();
                    break;

                //Gets news by ID
                case (LoadOptions.Get | LoadOptions.ObjectSingle):
                    response.WebsiteNews = websiteNewsDao.GetWebsiteArticle(request.NewsId);
                    break;

                #endregion

                #region Bucket News
                //gets a list of news
                case (LoadOptions.Get | LoadOptions.ObjectList):
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInBucket(siteConfiguration.NewsBucket).ToList();
                    break;

                //gets a list of news and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.LimitResult:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInBucket(siteConfiguration.NewsBucket, request.From, request.To).ToList();
                    break;

                //gets a list of news filtered by date
                case (LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.DateFilter):
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInBucket(siteConfiguration.NewsBucket, request.From, request.To).ToList();
                    break;

                //gets a list of news filtered by date and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.DateFilter | LoadOptions.LimitResult:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInBucket(siteConfiguration.NewsBucket, request.From, request.To, request.Offset, request.Number).ToList();
                    break;
                #endregion

                #region Category News

                //gets a list of news with a category filter
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Category:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInCategory(request.CategoryId).ToList();
                    break;

                //gets a list of news with a category filter and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Category | LoadOptions.LimitResult:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInCategory(request.CategoryId, request.Offset, request.Number).ToList();
                    break;

                //gets a list of news with a category filter and date filter
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Category | LoadOptions.DateFilter:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInCategory(request.CategoryId, request.From, request.To).ToList();
                    break;

                //gets a list of news with a category filter and date filter and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Category | LoadOptions.DateFilter | LoadOptions.LimitResult:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInCategory(request.CategoryId, request.From, request.To, request.Offset, request.Number).ToList();
                    break;
                #endregion

                #region List of Categories News

                //gets a list of news with a list of categories filter
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.CategoryList:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInCategories(request.CategoryIds).ToList();
                    break;

                //gets a list of news with a list of categories filter and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.CategoryList | LoadOptions.LimitResult:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInCategories(request.CategoryIds, request.Offset, request.Number).ToList();
                    break;

                //gets a list of news with a list of categories filter and date filter
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.CategoryList | LoadOptions.DateFilter:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInCategories(request.CategoryIds, request.From, request.To).ToList();
                    break;

                //gets a list of news with a list of categories filter and date filter and limited
                case LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.CategoryList | LoadOptions.DateFilter | LoadOptions.LimitResult:
                    response.WebsiteNewsList = websiteNewsDao.GetWebsiteArticleInCategories(request.CategoryIds, request.From, request.To, request.Offset, request.Number).ToList();
                    break;

                #endregion


                //the combination of load options is not implemented
                default:
                    var loadOptions = Array.ConvertAll(request.LoadOptions, value => value);
                    throw new NotImplementedException(String.Format("GetWhiteNewsContent does not implemented path for load option of {0}", String.Join(",", loadOptions)));
            }




            return response;
        }
    }
}
