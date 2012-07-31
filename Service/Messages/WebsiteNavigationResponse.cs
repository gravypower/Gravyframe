using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.MessageBase;
using System.Runtime.Serialization;
using BusinessObjects.Navigation;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class WebsiteNavigationResponse : ResponseBase
    {
        public WebsiteNavigationResponse() { }

        public WebsiteNavigationResponse(string correlationId) : base(correlationId) { }

        [DataMember]
        public IList<WebsiteNavigation> WhiteLabelContentList;

        [DataMember]
        public WebsiteNavigation WhiteLabelContent;
    }
}
