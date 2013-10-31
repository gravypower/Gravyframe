using System.Collections.Generic;
using System.Linq;
using Gravyframe.Configuration;
using Gravyframe.Data.News;

namespace Gravyframe.Data.InMemory.News
{
    public class InMemoryNewsDao : NewsDao<Models.News>
    {
        private readonly List<Models.News> _newsList;

        public InMemoryNewsDao(INewsConfiguration newsConfiguration) : base(newsConfiguration)
        {
            _newsList = new List<Models.News>();

            for (var i = 1; i < 100; i++)
            {
                _newsList.Add(new Models.News {Sequence = i, Title = "Test" + i, Body = "Test" + i});
            }
        }

        public override Models.News GetNews(string newsId)
        {
            return new Models.News();
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId)
        {
            return _newsList.Take(NewsConfiguration.DefaultListSize);
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize)
        {
            return _newsList.Take(listSize);
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize, int page)
        {
            var pagesToSkip = CalculateNumberToSkip(listSize, page);
            return _newsList.Skip(pagesToSkip).Take(listSize);
        }
    }
}
