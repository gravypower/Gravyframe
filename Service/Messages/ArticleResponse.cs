using System;
using System.Collections.Generic;
using System.Linq;
using Service.MessageBase;
using System.Runtime.Serialization;
using Service.DataTransferObjects;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class ArticleResponse: ResponseBase
    {
        public ArticleResponse() { }

        public ArticleResponse(string correlationId) : base(correlationId) { }

        [DataMember]
        public IList<ArticleDto> Articles;

        [DataMember]
        public ArticleDto Article;
    }
}
