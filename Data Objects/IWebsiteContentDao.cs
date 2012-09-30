using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Content;

namespace DataObjects
{
    public interface IWebsiteContentDao
    {
        WebsiteContent GetWebsiteContent(string websiteContentContentId);
        WebsiteContent GetCurrentWebsiteContent();
        IList<BusinessObjects.Content.WebsiteContent> GetCurrentWebsiteContentChildren();
    }
}
