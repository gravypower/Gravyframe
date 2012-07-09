using System;
using System.Collections.Generic;
using DataObjects.Sitecore.Constants;
using BusinessObjects;
using Sitecore.Data.Items;
using WebsiteKernel;
using DataObjects.Sitecore.ModelMapper;

namespace DataObjects.Sitecore.Implementation
{
    public class SitecoreArticleDao : IArticleDao
    {
        private readonly IArticleDaoMapper<Item> articleDaoMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreArticleDao"/> class.
        /// </summary>
        /// <param name="sitecoreContext">The sitecore context.</param>
        public SitecoreArticleDao(IArticleDaoMapper<Item> articleDaoMapper)
        {
            Guard.IsNotNull(() => articleDaoMapper);
            Guard.IsCorrectType<ArticleDaoMapper>(articleDaoMapper);

            this.articleDaoMapper = articleDaoMapper;
        }

        /// <summary>
        /// Gets the articles.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> GetArticles()
        {
            var articleBucket = Utilities.Sites.SiteContext.Database.GetItem(Items.ArticleBucket);
            var articlePath = "*";
            
            var fastQuery = String.Format("fast:{0}/{1}", articleBucket.Paths.FullPath, articlePath);

            var articleItems = Utilities.Sites.SiteContext.Database.SelectItems(fastQuery);

            var articles = new List<Article>();
            foreach (var item in articleItems)
            {
                articles.Add(articleDaoMapper.Map(item));
            }

            return articles;
        }
    }
}
