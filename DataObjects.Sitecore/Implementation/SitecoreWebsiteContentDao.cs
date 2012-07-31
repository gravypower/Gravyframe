using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Sitecore.Mapper;
using Sitecore.Data.Items;

namespace DataObjects.Sitecore.Implementation
{
    public class SitecoreWebsiteContentDao : IWebsiteContentDao
    {
        private readonly ISitecoreContext context;
        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreWhiteLabelContentDao" /> class.
        /// </summary>
        public SitecoreWebsiteContentDao()
        {
            context = new SitecoreContext();
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

        /// <summary>
        /// Gets the navigation items worker.
        /// </summary>
        /// <param name="navigationId">The navigation id.</param>
        /// <param name="navigationStartItem">The navigation start item.</param>
        /// <returns></returns>
        private IEnumerable<BusinessObjects.Content.WebsiteContent> GetNavigationItemsWorker(string navigationId, Item navigationStartItem)
        {
            var returnWhiteLabelContentList = new List<BusinessObjects.Content.WebsiteContent>();

            //iterate though the children that have the navigationId added to the Location Tree List Field
            foreach (var item in navigationStartItem.Children.Where(item => item["Location"].Contains(navigationId)))
            {
                returnWhiteLabelContentList.Add(context.GetItem<BusinessObjects.Content.WebsiteContent>(item.ID.Guid));
            }

            return returnWhiteLabelContentList;
        }

    }
}
