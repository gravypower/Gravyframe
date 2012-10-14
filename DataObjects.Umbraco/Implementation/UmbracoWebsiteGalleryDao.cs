using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.NodeFactory;
using umbraco.interfaces;
using umbraco.cms.businesslogic.media;
using WebsiteKernel.Umbraco.Constants;

namespace DataObjects.Umbraco.Implementation
{
    public class UmbracoWebsiteGalleryDao : IWebsiteGalleryDao
    {
        public IList<BusinessObjects.Gallery.GalleryImage> GetGalleryImages()
        {
            var galleryNode = Node.GetCurrent();

            var galleryImages = galleryNode.GetProperty("galleryImages").Value;

            var returnList = new List<BusinessObjects.Gallery.GalleryImage>();

            int galleryImagesMediaId;

            if (!String.IsNullOrEmpty(galleryImages) && int.TryParse(galleryImages, out galleryImagesMediaId))
            {
                var galleryImagesMedia = new Media(galleryImagesMediaId);
                if (galleryImagesMedia.ContentType.Alias == DocumentTypeAlias.Folder)
                {
                    foreach (var child in galleryImagesMedia.Children)
                    {
                        returnList.Add(
                           ModelMapper.Mapper.MapGalleryImage(child)
                        );
                    }
                }

            }

            return returnList;
        }
    }
}
