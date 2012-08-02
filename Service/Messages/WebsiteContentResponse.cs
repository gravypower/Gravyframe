﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.MessageBase;
using System.Runtime.Serialization;
using BusinessObjects.Content;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class WebsiteContentResponse : ResponseBase
    {
        public WebsiteContentResponse() { }

        public WebsiteContentResponse(string correlationId) : base(correlationId) { }

        [DataMember]
        public IList<WebsiteContent> WebsiteContentList;

        [DataMember]
        public WebsiteContent WebsiteContent;
    }
}