using System.Collections.Generic;
using Gravyframe.Data.Content;

namespace Gravyframe.Data.InMemory.Content
{
    public class InMemoryContentDao : IContentDao
    {
        public Models.Content GetContent(string contentId)
        {
            return new Models.Content{Title = "Test", Body = "Test"};
        }


        public IEnumerable<Models.Content> GetContentByCategory(string categoryId)
        {
            return
                new List<Models.Content>
                    {
                        new Models.Content {Title = "Test", Body = "Test"},
                        new Models.Content {Title = "Test", Body = "Test"},
                        new Models.Content {Title = "Test", Body = "Test"},
                        new Models.Content {Title = "Test", Body = "Test"},
                        new Models.Content {Title = "Test", Body = "Test"}
                    };
        }
    }
}
