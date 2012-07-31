using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Service.MessageBase;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class SiteConfigurationRequest : RequestBase<string>
    {
        public string SiteId { get; set; }
    }
}
