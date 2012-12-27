using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.MessageBase;
using System.Runtime.Serialization;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class WebsiteGalleryRequest : RequestBase<LoadOptions>
    {
        [DataMember]
        public IList<string> GalleryIds;

        [DataMember]
        public string GalleryId;
    }
}
