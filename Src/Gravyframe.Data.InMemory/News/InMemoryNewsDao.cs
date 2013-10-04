using System.Collections.Generic;
using System.Linq;
using Gravyframe.Constants;
using Gravyframe.Data.News;

namespace Gravyframe.Data.InMemory.News
{
    public class InMemoryNewsDao : NewsDao
    {
        private readonly List<Models.News> _newsList;

        public InMemoryNewsDao(INewsConstants newsConstants) : base(newsConstants)
        {
            _newsList = new List<Models.News>();

            for (var i = 0; i < 100; i++)
            {
                _newsList.Add(new Models.News { Title = "Test", Body = "Test" });
            }
        }

        public override Models.News GetNews(string newsId)
        {
            return new Models.News();
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId)
        {
            return _newsList.Take(NewsConstants.DefaultListSize);
        }
    }
}
