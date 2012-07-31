using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Service.Messages;

namespace Service.ServiceContracts
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IWebsiteNavigationService
    {
        [OperationContract]
        WebsiteNavigationResponse GetWhiteLabelContent(WebsiteNavigationRequest request);    
    }
}
