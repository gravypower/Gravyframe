using System;
using System.Linq;
using Sitecore.Search.Crawlers;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Search;


namespace WebsiteKernel.Search.Sitecore
{
    public class StandardDatabaseCrawler : DatabaseCrawler
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
