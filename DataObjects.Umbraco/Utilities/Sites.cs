using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.interfaces;
using umbraco.NodeFactory;

namespace DataObjects.Umbraco.Utilities
{
    public class Sites
    {

        public static INode GetHomeItem()
        {
            return GetHomeItem(Node.GetCurrent());
        }

        public static INode GetHomeItem(INode item)
        {
            INode homeItem;
            var domains = umbraco.library.GetCurrentDomains(item.Id);
            
            if (domains == null)
            {
                if (item.NodeTypeAlias == WebsiteKernel.Umbraco.Constants.DocumentTypeAlias.WebsiteSite)
                {
                    homeItem = item.ChildrenAsList.Where(x => x.Name.Equals("home", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                }
                else
                {
                    homeItem = GetHomeItem(item.Parent);
                }
            }
            else
            {
                var domian = domains.FirstOrDefault();

                homeItem = new Node(domian.RootNodeId);
            }

            return homeItem;
        }

        public static INode GetConfigItem()
        {
            return GetConfigItem(GetHomeItem());
        }

        public static INode GetConfigItem(INode siteItem)
        {
            var homeItem = GetHomeItem(siteItem);
            return homeItem.Parent.ChildrenAsList.Where(x => x.Name.Equals("Configuration", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
    }
}
