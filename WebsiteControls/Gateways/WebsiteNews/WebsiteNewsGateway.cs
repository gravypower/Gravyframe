using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Messages;
using Service.ServiceContracts;
using WebsiteKernel;

namespace WebsiteControls.Gateways.WebsiteNews
{
    public class WebsiteNewsGateway : GatewayBase<LoadOptions>, IWebsiteNewsGateway
    {
        private readonly IWebsiteNewsService websiteNewsService;

        public WebsiteNewsGateway(
            IWebsiteNewsService websiteNewsService, 
            IClientTagService clientTagService,
            IItemIDService itemIDService)
            : base(itemIDService, clientTagService)
        {
            //make sure the injection he worked.
            Guard.IsNotNull(() => websiteNewsService);
            
            //wire up the injected service
            this.websiteNewsService = websiteNewsService;
            
        }

        public BusinessObjects.News.WebsiteNews GetCurrentNews()
        {
            BusinessObjects.News.WebsiteNews returnWhiteLabelNews = null;

            //check that context item for the current page so we don't have to fetch it again
            if (!HttpContext.Current.Items.Contains("CurrentNews"))
            {
                //its not there get it form the service
                returnWhiteLabelNews = GetWhiteLabelNews(new[] { LoadOptions.Get, LoadOptions.Current, LoadOptions.ObjectSingle }).WebsiteNews;

                //save it in the context items 
                HttpContext.Current.Items.Add("CurrentNews", returnWhiteLabelNews);
            }
            else
            {
                //it was there so lets just reuse it
                returnWhiteLabelNews = HttpContext.Current.Items["CurrentNews"] as BusinessObjects.News.WebsiteNews;
            }

            return returnWhiteLabelNews;
        }

        public BusinessObjects.News.WebsiteNews GetNews(object newsItemID)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectSingle };
            request.NewsId = itemIDService.GetItemId(newsItemID);
            return GetWhiteLabelNews(null, request).WebsiteNews;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetAllNews()
        {
            return GetWhiteLabelNews(new[] { LoadOptions.Get, LoadOptions.ObjectList }).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetAllNews(int offset, int number)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.LimitResult, LoadOptions.ObjectList };
            request.Offset = offset;
            request.Number = number;
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(object categoryId)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.Category, LoadOptions.ObjectList };
            request.CategoryId = itemIDService.GetItemId(categoryId);
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(IList<object> categoryIds)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.CategoryList, LoadOptions.ObjectList };
            request.CategoryIds = itemIDService.GetItemIds(categoryIds).ToList();
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetAllNews(DateTime from, DateTime to)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectList, LoadOptions.DateFilter };
            request.From = from;
            request.To = to;
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(object categoryId, DateTime from, DateTime to)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Category, LoadOptions.DateFilter, LoadOptions.ObjectList };
            request.From = from;
            request.From = to;
            request.CategoryId = itemIDService.GetItemId(categoryId);
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(IList<object> categoryIds, DateTime from, DateTime to)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Category, LoadOptions.DateFilter, LoadOptions.ObjectList };
            request.From = from;
            request.From = to;
            request.CategoryIds = itemIDService.GetItemIds(categoryIds).ToList();
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetAllNews(DateTime from, DateTime to, int offset, int number)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectList, LoadOptions.DateFilter, LoadOptions.LimitResult };
            request.From = from;
            request.From = to;
            request.Offset = offset;
            request.Number = number;
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(object categoryId, DateTime from, DateTime to, int offset, int number)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.Category, LoadOptions.ObjectList, LoadOptions.DateFilter, LoadOptions.LimitResult };
            request.From = from;
            request.From = to;
            request.CategoryId = itemIDService.GetItemId(categoryId);
            request.Offset = offset;
            request.Number = number;
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }

        public IList<BusinessObjects.News.WebsiteNews> GetCategoryNews(IList<object> categoryIds, DateTime from, DateTime to, int offset, int number)
        {
            var request = new WebsiteNewsRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.Category, LoadOptions.ObjectList, LoadOptions.DateFilter, LoadOptions.LimitResult };
            request.From = from;
            request.From = to;
            request.CategoryIds = itemIDService.GetItemIds(categoryIds).ToList();
            request.Offset = offset;
            request.Number = number;
            return GetWhiteLabelNews(null, request).WebsiteNewsList;
        }


        private WebsiteNewsResponse GetWhiteLabelNews(LoadOptions[] loadOptions = null, WebsiteNewsRequest request = null)
        {
            //check that we have not passed in a request
            if (request == null)
            {
                //create a new request
                request = new WebsiteNewsRequest();
            }

            if (loadOptions != null)
            {
                //set the load options form what was passed in
                request.LoadOptions = loadOptions;
            }

            request.ClientTag = clientTagService.GetClientTag();

            //make the call
            var response = websiteNewsService.GetWebsiteNews(request);

            //make sure all is well
            Correlate(request, response);

            //return it to 
            return response;
        }
    }
}