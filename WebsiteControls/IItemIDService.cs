using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteControls
{
    public interface IItemIDService
    {
        string GetContextItemId();

        string GetItemId(object itemId);

        IEnumerable<string> GetItemIds(IEnumerable<object> itemIds); 
    }
}