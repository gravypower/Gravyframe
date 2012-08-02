using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteControls;
using umbraco.NodeFactory;

namespace UmbracoClient.WebsiteControls
{
    public class ItemIDService : IItemIDService
    {
        public string GetContextItemId()
        {
            return Node.GetCurrent().Id.ToString();
        }

        public string GetItemId(object itemId)
        {
            return itemId.ToString();
        }

        public IEnumerable<string> GetItemIds(IEnumerable<object> itemIds)
        {
            var returnIdList = new List<string>();


            foreach (var itemId in itemIds)
            {
                returnIdList.Add(GetItemId(itemId));
            }

            return returnIdList;
        }
    }
}