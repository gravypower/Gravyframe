using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Service.MessageBase;
using BusinessObjects.Gallery;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class WebsiteGalleryResponse : ResponseBase
    {
        public WebsiteGalleryResponse() { }

        public WebsiteGalleryResponse(string correlationId) : base(correlationId) { }

        [DataMember]
        public IList<GalleryImage> GalleryImagetList;
    }
}
