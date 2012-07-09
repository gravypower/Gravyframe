using System;
using System.Linq;
using Service.MessageBase;
using System.Runtime.Serialization;
using Service.Criteria;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class ArticleRequest : RequestBase
    {
        /// <summary>
        /// Selection criteria and sort order
        /// </summary>
        [DataMember]
        public ArticleCriteria Criteria;
    }
}
