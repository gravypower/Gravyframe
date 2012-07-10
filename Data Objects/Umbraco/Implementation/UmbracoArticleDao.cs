using System;
using System.Collections.Generic;
using System.Linq;
using umbraco.NodeFactory;
using WebsiteKernel;
using DataObjects.Umbraco.ModelMapper;
using BusinessObjects;

namespace DataObjects.Umbraco.Implementation
{
    public class UmbracoArticleDao : IArticleDao
    {

        private readonly IArticleDaoMapper<Node> articleDaoMapper;

        public UmbracoArticleDao(IArticleDaoMapper<Node> articleDaoMapper)
        {
            Guard.IsNotNull(() => articleDaoMapper);
            Guard.IsCorrectType<ArticleDaoMapper>(articleDaoMapper);

            this.articleDaoMapper = articleDaoMapper;
        }

        public IEnumerable<BusinessObjects.Article> GetArticles()
        {
            var articleBucket = new Node(Constants.Content.NewsFolder);
          

            var articles = new List<Article>();
            foreach (Node item in articleBucket.Children)
            {
                articles.Add(articleDaoMapper.Map(item));
            }

            return articles;
        }
    }
}
