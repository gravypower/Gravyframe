using System.Collections.Generic;

namespace Gravyframe.Data.Content
{
    public interface IContentDao
    {
        Models.Content GetContent(string contentId);

        IEnumerable<Models.Content> GetContentByCategory(string categoryId);
    }
}
