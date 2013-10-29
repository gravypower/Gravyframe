using System.Collections.Generic;
using Gravyframe.Data.Content;

namespace Gravyframe.Data.InMemory.Content
{
    public class InMemoryContentDao : ContentDao<Models.Content>
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

        public override Models.Content GetContent(string contentId)
        {
            return new Models.Content{Title = "Test", Body = "Test"};
        }

        public override IEnumerable<Models.Content> GetContentByCategory(string categoryId)
        {
            return _contentList;
        }
    }
}
