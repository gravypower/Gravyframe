using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteControls.Gateways.WebsiteEvent
{
    public interface IWebsiteEventGateway
    {
        BusinessObjects.Event.WebsiteEvent GetCurrentEvents();
        BusinessObjects.Event.WebsiteEvent GetEvent(object eventItemId);
        IList<BusinessObjects.Event.WebsiteEvent> GetAllEvents();
        IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(object categoryId);
        IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(IList<object> categoryIds);

        IList<BusinessObjects.Event.WebsiteEvent> GetAllEvents(DateTime from, DateTime to);
        IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(object categoryId, DateTime from, DateTime to);
        IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(IList<object> categoryIds, DateTime from, DateTime to);

        IList<BusinessObjects.Event.WebsiteEvent> GetAllEvents(DateTime from, DateTime to, int offset, int number);
        IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(object categoryId, DateTime from, DateTime to, int offset, int number);
        IList<BusinessObjects.Event.WebsiteEvent> GetCategoryEvents(IList<object> categoryIds, DateTime from, DateTime to, int offset, int number);
    }
}
