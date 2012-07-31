using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Service.Messages;

namespace Service.ServiceContracts
{
    public interface IWebsiteEventService : IService
    {
        [OperationContract]
        WebsiteEventResponse GetWebsiteEvent(WebsiteEventRequest request);
    }
}
