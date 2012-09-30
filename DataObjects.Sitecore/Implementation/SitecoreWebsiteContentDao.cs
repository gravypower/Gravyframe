using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Sitecore.Mapper;
using Sitecore.Data.Items;

namespace DataObjects.Sitecore.Implementation
{
    public class SitecoreWebsiteContentDao :SitecoreDao, IWebsiteContentDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreWhiteLabelContentDao" /> class.
        /// </summary>
        public SitecoreWebsiteContentDao()
        {
        }

        public BusinessObjects.Content.WebsiteContent GetWebsiteContent(string websiteContentContentId)
        {
            var contentGuid = Guid.Parse(websiteContentContentId);
            return GetWebsiteContent(contentGuid);
        }

        public BusinessObjects.Content.WebsiteContent GetCurrentWebsiteContent()
        {
            return context.GetCurrentItem<BusinessObjects.Content.WebsiteContent>();
        }

        /// <summary>
        /// Gets the content of the white label.
        /// </summary>
        /// <param name="whiteLabelContentId">The white label content id.</param>
        /// <returns></returns>
        private BusinessObjects.Content.WebsiteContent GetWebsiteContent(Guid websiteContentId)
        {
            return context.GetItem<BusinessObjects.Content.WebsiteContent>(websiteContentId);
        }


        public IList<BusinessObjects.Content.WebsiteContent> GetCurrentWebsiteContentChildren()
        {
            throw new NotImplementedException();
        }
    }
}
