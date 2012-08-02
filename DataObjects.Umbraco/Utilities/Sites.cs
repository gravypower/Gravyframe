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
        public static INode GetContentStartItem()
        {
            return GetHomeItem().Parent;
        }
        public static INode GetHomeItem()
        {
            var domains = umbraco.library.GetCurrentDomains(Node.GetCurrent().Id);
            var domian = domains.FirstOrDefault();
            return new Node(domian.RootNodeId);
        }

        public static INode GetConfigItem()
        {
            return GetConfigItem(GetContentStartItem());
        }

        public static INode GetConfigItem(INode siteItem)
        {
            return siteItem.ChildrenAsList.Where(x => x.Name.Equals("Configuration", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
    }
}
