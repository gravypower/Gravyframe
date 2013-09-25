using System.Collections.Generic;
using Gravyframe.Data.Content;

namespace Gravyframe.Data.InMemory.Content
{
    public class InMemoryContentDao : IContentDao
    {
        private List<Models.Content> _contentList;

        public InMemoryContentDao()
        {
            _contentList = new List<Models.Content>();

            for (int i = 0; i < 100; i++)
            {
               _contentList.Add(new Models.Content { Title = "Test", Body = "Test" });
            }
        }

        public Models.Content GetContent(string contentId)
        {
            return new Models.Content{Title = "Test", Body = "Test"};
        }

        public IEnumerable<Models.Content> GetContentByCategory(string categoryId)
        {
            return _contentList;
        }
    }
}
