using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Event;

namespace DataObjects
{
    public interface IWebsiteEventDao:IWebsiteArticleDao<WebsiteEvent>
    {
    }
}
