using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Messages;
using Service.ServiceContracts;
using WebsiteKernel;
using DataObjects;

namespace Service.ServiceImplementations
{
    public class WebsiteGalleryService : Service<LoadOptions>, IWebsiteGalleryService
    {
        private readonly IWebsiteGalleryDao websiteGalleryDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;

        public WebsiteGalleryService(IWebsiteGalleryDao websiteGalleryDao, ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => websiteGalleryDao);
            Guard.IsNotNull(() => siteConfigurationDao);

            this.siteConfigurationDao = siteConfigurationDao;
            this.websiteGalleryDao = websiteGalleryDao;

        }

        public WebsiteGalleryResponse GetWebsiteGallery(WebsiteGalleryRequest request)
        {
            var response = new WebsiteGalleryResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            var siteConfiguration = siteConfigurationDao.GetSiteConfiguration();


            switch (request.LoadOptions.FlagLoadOptions())
            {
                #region Single Event
                //Gets the current Event
                case (LoadOptions.Get | LoadOptions.ObjectList ):
                    response.GalleryImagetList = websiteGalleryDao.GetGalleryImages();
                    break;

                //Gets Event by ID
                case (LoadOptions.Get | LoadOptions.ObjectList | LoadOptions.Current):
                    response.GalleryImagetList = websiteGalleryDao.GetGalleryImages();
                    break;

                #endregion

                //the combination of load options is not implemented
                default:
                    var loadOptions = Array.ConvertAll(request.LoadOptions, value => value);
                    throw new NotImplementedException(String.Format("GetWebsiteGallery does not implemented path for load option of {0}", String.Join(",", loadOptions)));
            }

            return response;
        }
    }
}
