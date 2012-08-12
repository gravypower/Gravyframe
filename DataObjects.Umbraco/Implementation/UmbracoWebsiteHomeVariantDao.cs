using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.NodeFactory;
using BusinessObjects.Content;

namespace DataObjects.Umbraco.Implementation
{
    public class UmbracoWebsiteHomeVariantDao : IWebsiteHomeVariantDao
    {
        public IEnumerable<BusinessObjects.Content.HomeVariant> GetHomeVariant()
        {
            var returnList = new List<HomeVariant>();
            var homeVariants = new Node(Constants.Nodes.HomeVariants);
            foreach (var node in homeVariants.ChildrenAsList)
            {
                returnList.Add(ModelMapper.Mapper.MapHomeVariant(node));
            }

            return returnList;
        }
    }
}
