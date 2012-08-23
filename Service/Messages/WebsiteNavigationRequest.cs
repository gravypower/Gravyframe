using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.MessageBase;
using System.Runtime.Serialization;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class WebsiteNavigationRequest : RequestBase<string>
    {
        /// <summary>
        /// Gets or sets the side navigation start item.
        /// </summary>
        /// <value>The side navigation start item.</value>
        [DataMember]
        public string SideNavigationStartItem { get; set; }

        [DataMember]
        public string ContentId { get; set; }
    }
}
