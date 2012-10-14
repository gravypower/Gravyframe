using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public interface IWebsiteGalleryDao
    {
        IList<BusinessObjects.Gallery.GalleryImage> GetGalleryImages();
    }
}
