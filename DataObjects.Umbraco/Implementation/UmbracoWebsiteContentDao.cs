using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace DataObjects.Umbraco.Implementation
{
    public class UmbracoWebsiteContentDao : IWebsiteContentDao
    {
        public BusinessObjects.Content.WebsiteContent GetWebsiteContent(string websiteContentContentId)
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.Content.WebsiteContent GetCurrentWebsiteContent()
        {
            return ModelMapper.Mapper.MapWebsiteContent(Node.GetCurrent());
        }

        public IList<BusinessObjects.Content.WebsiteContent> GetCurrentWebsiteContentChildren()
        {
            var returnList = new List<BusinessObjects.Content.WebsiteContent>();
            foreach (INode item in Node.GetCurrent().Children)
            {
                returnList.Add(ModelMapper.Mapper.MapWebsiteContent(item));
            }
            return returnList;
        }
    }
}
