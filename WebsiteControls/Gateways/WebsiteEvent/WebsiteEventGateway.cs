using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Messages;
using Service.ServiceContracts;
using WebsiteKernel;

namespace WebsiteControls.Gateways.WebsiteEvent
{
    public class WebsiteEventGateway : GatewayBase<LoadOptions>, IWebsiteEventGateway
    {
        private readonly IWebsiteEventService websiteEventService;

        public WebsiteEventGateway(
            IWebsiteEventService websiteEventService, 
            IClientTagService clientTagService,
            IItemIDService itemIDService)
            : base(itemIDService, clientTagService)
        {
            //make sure the injection he worked.
            Guard.IsNotNull(() => websiteEventService);
            
            //wire up the injected service
            this.websiteEventService = websiteEventService;
            
        }

        public BusinessObjects.Event.WebsiteEvent GetCurrentEvents()
        {
            BusinessObjects.Event.WebsiteEvent returnWebsiteEvent = null;

            //check that context item for the current page so we don't have to fetch it again
            if (!HttpContext.Current.Items.Contains("CurrentEvent"))
            {
                //its not there get it form the service
                returnWebsiteEvent = GetWebsiteEvent(new[] { LoadOptions.Get, LoadOptions.Current, LoadOptions.ObjectSingle }).WebsiteEvent;

                //save it in the context items 
                HttpContext.Current.Items.Add("CurrentEvent", returnWebsiteEvent);
            }
            else
            {
                //it was there so lets just reuse it
                returnWebsiteEvent = HttpContext.Current.Items["CurrentEvent"] as BusinessObjects.Event.WebsiteEvent;
            }

            return returnWebsiteEvent;
        }

        public BusinessObjects.Event.WebsiteEvent GetEvent(object eventItemID)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectSingle };
            request.EventId = itemIDService.GetItemId(eventItemID);
            return GetWebsiteEvent(null, request).WebsiteEvent;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetAllEvents()
        {
            return GetWebsiteEvent(new[] { LoadOptions.Get, LoadOptions.ObjectList }).WebsiteEventList;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(object categoryId)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.Category, LoadOptions.ObjectList };
            request.CategoryId = itemIDService.GetItemId(categoryId);
            return GetWebsiteEvent(null, request).WebsiteEventList;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(IList<object> categoryIds)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.CategoryList, LoadOptions.ObjectList };
            request.CategoryIds = itemIDService.GetItemIds(categoryIds).ToList();
            return GetWebsiteEvent(null, request).WebsiteEventList;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetAllEvents(DateTime from, DateTime to)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectList, LoadOptions.DateFilter };
            request.From = from;
            request.To = to;
            return GetWebsiteEvent(null, request).WebsiteEventList;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(object categoryId, DateTime from, DateTime to)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Category, LoadOptions.DateFilter, LoadOptions.ObjectList };
            request.From = from;
            request.From = to;
            request.CategoryId = itemIDService.GetItemId(categoryId);
            return GetWebsiteEvent(null, request).WebsiteEventList;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(IList<object> categoryIds, DateTime from, DateTime to)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Category, LoadOptions.DateFilter, LoadOptions.ObjectList };
            request.From = from;
            request.From = to;
            request.CategoryIds = itemIDService.GetItemIds(categoryIds).ToList();
            return GetWebsiteEvent(null, request).WebsiteEventList;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetAllEvents(DateTime from, DateTime to, int offset, int number)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.ObjectList, LoadOptions.DateFilter, LoadOptions.LimitResult };
            request.From = from;
            request.From = to;
            request.Offset = offset;
            request.Number = number;
            return GetWebsiteEvent(null, request).WebsiteEventList;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(object categoryId, DateTime from, DateTime to, int offset, int number)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.Category, LoadOptions.ObjectList, LoadOptions.DateFilter, LoadOptions.LimitResult };
            request.From = from;
            request.From = to;
            request.CategoryId = itemIDService.GetItemId(categoryId);
            request.Offset = offset;
            request.Number = number;
            return GetWebsiteEvent(null, request).WebsiteEventList;
        }

        public IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(IList<object> categoryIds, DateTime from, DateTime to, int offset, int number)
        {
            var request = new WebsiteEventRequest();
            request.LoadOptions = new[] { LoadOptions.Get, LoadOptions.Category, LoadOptions.ObjectList, LoadOptions.DateFilter, LoadOptions.LimitResult };
            request.From = from;
            request.From = to;
            request.CategoryIds = itemIDService.GetItemIds(categoryIds).ToList(); ;
            request.Offset = offset;
            request.Number = number;
            return GetWebsiteEvent(null, request).WebsiteEventList;
        }


        private WebsiteEventResponse GetWebsiteEvent(LoadOptions[] loadOptions = null, WebsiteEventRequest request = null)
        {
            //check that we have not passed in a request
            if (request == null)
            {
                //create a new request
                request = new WebsiteEventRequest();
            }

            if (loadOptions != null)
            {
                //set the load options form what was passed in
                request.LoadOptions = loadOptions;
            }

            //TODO: get this from the config Website.ClientTag
            request.ClientTag = clientTagService.GetClientTag();

            //make the call
            var response = websiteEventService.GetWebsiteEvent(request);

            //make sure all is well
            Correlate(request, response);

            //return it to 
            return response;
        }
    }
}