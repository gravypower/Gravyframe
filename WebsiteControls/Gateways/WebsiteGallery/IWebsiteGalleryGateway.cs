using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteControls.Gateways.WebsiteGallery
{
    public interface IWebsiteGalleryGateway
    {
        IList<BusinessObjects.Gallery.GalleryImage> GetCurrentGallery();

        IList<BusinessObjects.Gallery.GalleryImage> GetGallery(object itemID);
    }
}
