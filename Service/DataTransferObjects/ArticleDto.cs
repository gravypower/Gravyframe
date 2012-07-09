using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Service.DataTransferObjects
{
    [DataContract(Name = "Article", Namespace = "http://www.gravypower.net/types/")]
    public class ArticleDto
    {

        [DataMember]
        public Guid ArticleId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public string ArticleBody { get; set; }

        [DataMember]
        public bool AllowComments { get; set; }
    }
}
