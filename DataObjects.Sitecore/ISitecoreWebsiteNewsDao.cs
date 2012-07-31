using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;

namespace DataObjects.Sitecore
{
    public interface ISitecoreWebsiteNewsDao
    {
        IEnumerable<Item> SearchWebsiteNewsItems(string websiteNewsName);
    }
}
