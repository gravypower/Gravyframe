using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Service.Messages;

namespace Service.ServiceContracts
{
    public interface IWebsiteNewsService : IService
    {
        [OperationContract]
        WebsiteNewsResponse GetWebsiteNews(WebsiteNewsRequest request);
    }
}
