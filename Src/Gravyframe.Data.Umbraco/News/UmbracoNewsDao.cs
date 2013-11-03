using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Examine;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Models.Umbraco;
using Gravyframe.Kernel.Umbraco.Facades;

namespace Gravyframe.Data.Umbraco.News
{
    public class UmbracoNewsDao : NewsDao<UmbracoNews>
    {
        public const string BodyAlias = "body";
        public const string TitleAlias = "title";
        public const string CategoriesAlias = "categories";

        protected readonly ISearcher Searcher;
        protected readonly INodeFactoryFacade NodeFactoryFacade;

        public UmbracoNewsDao(INewsConfiguration newsConfiguration, INodeFactoryFacade nodeFactoryFacade, ISearcher searcher)
            : base(newsConfiguration)
        {
            Searcher = searcher;
            NodeFactoryFacade = nodeFactoryFacade;
        }

        public override UmbracoNews GetNews(string siteId, string newsId)
        {
            return GetNews(newsId);
        }

        public override UmbracoNews GetNews(string newsId)
        {
            var node = NodeFactoryFacade.GetNode(int.Parse(newsId));

            if (node == null || node.Id == 0)
                return null;

            var umbracoNews = new UmbracoNews
            {
                Id = node.Id,
                Sequence = 0
            };

            if (node.GetProperty(BodyAlias) != null)
            {
                umbracoNews.Body = node.GetProperty(BodyAlias).Value;
            }

            if (node.GetProperty(TitleAlias) != null)
            {
                umbracoNews.Title = node.GetProperty(TitleAlias).Value;
            }

            return umbracoNews;
        }

        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string categoryId)
        {
            return GetAllNewsByCategoryId(categoryId).Take(NewsConfiguration.DefaultListSize);
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
            var query = searchCriteria.Field(CategoriesAlias, categoryId).Compile();

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

        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string siteId, string categoryId)
        {
            return GetNewsByCategoryId(categoryId);
        }

        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize)
        {
            return GetNewsByCategoryId(categoryId, listSize);
        }

        public override IEnumerable<UmbracoNews> GetNewsByCategoryId(string siteId, string categoryId, int listSize, int page)
        {
            return GetNewsByCategoryId(categoryId, listSize, page);
        }
    }
}
