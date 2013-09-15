using System;
using Gravyframe.Data.Content;

namespace Gravyframe.Data.InMemory.Content
{
    public class InMemoryContentDao : IContentDao
    {
        public Models.Content GetContent()
        {
            return new Models.Content{Title = "Test", Body = "Test"};
        }
    }
}
