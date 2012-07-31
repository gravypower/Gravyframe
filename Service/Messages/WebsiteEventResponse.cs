using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Service.MessageBase;
using BusinessObjects.Content;
using BusinessObjects.Event;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class WebsiteEventResponse : ResponseBase
    {
        public WebsiteEventResponse() { }

        public WebsiteEventResponse(string correlationId) : base(correlationId) { }

        [DataMember]
        public IList<WebsiteContent> WebsiteContentList;

        [DataMember]
        public IList<WebsiteEvent> WebsiteEventList;

        [DataMember]
        public WebsiteEvent WebsiteEvent;

    }
}
