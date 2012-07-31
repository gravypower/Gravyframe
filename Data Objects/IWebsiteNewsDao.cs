using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.News;

namespace DataObjects
{
    public interface IWebsiteNewsDao : IWebsiteArticleDao<WebsiteNews>
    {
    }
}
