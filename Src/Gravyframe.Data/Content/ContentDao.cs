using System.Collections.Generic;

namespace Gravyframe.Data.Content
{
    public abstract class ContentDao<TContent> where TContent : Models.Content
    {
        public abstract TContent GetContent(string contentId);

        public abstract IEnumerable<TContent> GetContentByCategory(string categoryId);
    }
}
