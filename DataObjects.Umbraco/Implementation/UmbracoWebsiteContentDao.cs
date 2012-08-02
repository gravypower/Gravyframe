using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.NodeFactory;

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
    }
}
