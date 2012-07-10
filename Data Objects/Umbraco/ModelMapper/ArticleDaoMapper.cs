using System;
using System.Linq;
using umbraco.NodeFactory;

namespace DataObjects.Umbraco.ModelMapper
{
    internal abstract class ArticleDaoMapper : IArticleDaoMapper<Node>
    {

        protected ArticleDaoMapper()
        {
        }

        public abstract BusinessObjects.Article Map(Node item);
        public abstract Node Map(BusinessObjects.Article article);
    }
}
