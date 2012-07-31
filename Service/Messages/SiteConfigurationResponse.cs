using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BusinessObjects;
using Service.MessageBase;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class SiteConfigurationResponse : ResponseBase
    {
        public SiteConfigurationResponse() { }

        public SiteConfigurationResponse(string correlationId) : base(correlationId) { }

        [DataMember]
        public SiteConfiguration SiteConfiguration;
    }
}
