using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Service.Criteria
{
    /// <summary>
    /// Base class that holds criteria for queries.
    /// </summary>
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class Criteria
    {
        /// <summary>
        /// Sort expression of the criteria.
        /// </summary>
        [DataMember]
        public string SortExpression { get; set; }
    }
}
