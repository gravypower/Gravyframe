using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Service.Criteria
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class ArticleCriteria : Criteria
    {
        /// <summary>
        /// Unique article identifier.
        /// </summary>
        [DataMember]
        public Guid ArticleId { get; set; }

        /// <summary>
        /// The article name.
        /// </summary>
        [DataMember]
        public string ArticleName { get; set; }

        /// <summary>
        /// Date range low end. 
        /// </summary>
        [DataMember]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Date range high end.
        /// </summary>
        [DataMember]
        public DateTime DateThru { get; set; }
    }
}
