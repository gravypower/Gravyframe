using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Examine;
using Gravyframe.Constants.Umbraco;
using Gravyframe.Data.News;
using Gravyframe.Kernel.Umbraco;
using Gravyframe.Models.Umbraco;

namespace Gravyframe.Data.Umbraco.News
{
    public class UmbracoNewsDao : NewsDao<UmbracoNews>
    {
        protected readonly ISearcher Searcher;
        protected readonly INodeFactoryFacade NodeFactoryFacade;

        public UmbracoNewsDao(int newsConfigurationNodeId, INodeFactoryFacade nodeFactoryFacade, ISearcher searcher)
            :base(new UmbracoNewsConstants(nodeFactoryFacade.GetNode(newsConfigurationNodeId)))
        {
            Searcher = searcher;
            NodeFactoryFacade = nodeFactoryFacade;
        }

        public override UmbracoNews GetNews(string newsId)
        {
            var node = NodeFactoryFacade.GetNode(int.Parse(newsId));
            return new UmbracoNews
                {
                    Body = node.GetProperty("Body").Value,
                    Title = node.GetProperty("Title").Value,
                    Sequence = 0
                };
        }

        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string categoryId)
        {

            return GetAllNewsByCategoryId(categoryId).Take(NewsConstants.DefaultListSize);
        }

        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string categoryId, int listSize)
        {
            return GetAllNewsByCategoryId(categoryId).Take(listSize);
        }

        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string categoryId, int listSize, int page)
        {
            var pagesToSkip = CalculateNumberToSkip(listSize, page);
            return GetAllNewsByCategoryId(categoryId).Skip(pagesToSkip).Take(listSize);
        }

        protected virtual IEnumerable<UmbracoNews> GetAllNewsByCategoryId(string categoryId)
        {
            var searchCriteria = Searcher.CreateSearchCriteria();
            var query = searchCriteria.Field("categoryId", categoryId).Compile();

            var newsList = new List<UmbracoNews>();

            var sequence = 1;
            foreach (var result in Searcher.Search(query))
            {
                var news = GetNews(result.Id.ToString(CultureInfo.InvariantCulture));
                news.Sequence = sequence++;
                newsList.Add(news);
            }
            return newsList;
        }
    }
}
