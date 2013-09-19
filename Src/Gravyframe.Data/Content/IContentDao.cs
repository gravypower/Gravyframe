using System.Collections.Generic;

namespace Gravyframe.Data.Content
{
    public interface IContentDao
    {
        Models.Content GetContent();

        IEnumerable<Models.Content> GetContentByCategory(string categoryId);
    }
}
