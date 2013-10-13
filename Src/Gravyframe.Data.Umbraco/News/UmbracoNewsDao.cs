using System.Collections.Generic;
using System.Globalization;
using Examine;
using Examine.LuceneEngine.SearchCriteria;
using Gravyframe.Data.News;
using Gravyframe.Kernel.Umbraco;
using umbraco.interfaces;

namespace Gravyframe.Data.Umbraco.News
{
    public class UmbracoNewsDao:NewsDao
    {
        protected readonly ISearcher Searcher;
        protected readonly INodeFactoryFacade NodeFactoryFacade;
        protected readonly INode NewsConfigrationNode;

        public UmbracoNewsDao(INode newsConfigrationNode, INodeFactoryFacade nodeFactoryFacade, ISearcher searcher)
        {
            Searcher = searcher;
            NodeFactoryFacade = nodeFactoryFacade;
            NewsConfigrationNode = newsConfigrationNode;
        }

        public override Models.News GetNews(string newsId)
        {
            var node = NodeFactoryFacade.GetNode(int.Parse(newsId));
            return new Models.News
                {
                    Body = node.GetProperty("Body").Value,
                    Title = node.GetProperty("Title").Value,
                    Sequence = 0
                };
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId)
        {
            var searchCriteria = Searcher.CreateSearchCriteria();
            var query = searchCriteria.Field("categoryId", categoryId).Compile();

            var newsList = new List<Models.News>();
            foreach (var result in Searcher.Search(query))
            {
                newsList.Add(GetNews(result.Id.ToString(CultureInfo.InvariantCulture)));
            }

            return newsList;
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
