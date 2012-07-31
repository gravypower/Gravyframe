using System;
using System.Linq;
using scSearchContrib.Crawler.Crawlers;
using Sitecore.Search;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;

namespace WebsiteKernel.Search.Sitecore
{
    public class CustomDatabaseCrawler : AdvancedDatabaseCrawler
    {
        protected override void AddItem(Item item, IndexUpdateContext context)
        {
            var excludeFromSearch = (CheckboxField)item.Fields["ExcludeFromSearch"];
            if (excludeFromSearch == null || excludeFromSearch.Checked == false)
            {
                base.AddItem(item, context);
            }
        }
    }
}
