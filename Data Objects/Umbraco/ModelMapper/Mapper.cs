using System;
using System.Linq;
using umbraco.NodeFactory;

namespace DataObjects.Umbraco.ModelMapper
{
    internal class Mapper: ArticleDaoMapper, IArticleDaoMapper<Node>
    {

        public override BusinessObjects.Article Map(Node item)
        {
            var returnArticle = new BusinessObjects.Article();

            returnArticle.AllowComments = item.Properties["allowComments"].Value.Equals("0", StringComparison.CurrentCultureIgnoreCase) ;
            returnArticle.ArticleBody = item.Properties["articleBody"].Value;
            returnArticle.Title = item.Properties["title"].Value;
            returnArticle.Summary = item.Properties["summary"].Value;

            return returnArticle;
        }

        public override Node Map(BusinessObjects.Article article)
        {
            throw new NotImplementedException();
        }
    }
}
