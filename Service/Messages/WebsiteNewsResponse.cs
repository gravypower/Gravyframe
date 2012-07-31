using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Service.MessageBase;
using BusinessObjects.Content;
using BusinessObjects.News;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class WebsiteNewsResponse : ResponseBase
    {
        public WebsiteNewsResponse() { }

        public WebsiteNewsResponse(string correlationId) : base(correlationId) { }

        [DataMember]
        public IList<WebsiteContent> WebsiteContentList;

        [DataMember]
        public IList<WebsiteNews> WebsiteNewsList;

        [DataMember]
        public WebsiteNews WebsiteNews;

    }
}
