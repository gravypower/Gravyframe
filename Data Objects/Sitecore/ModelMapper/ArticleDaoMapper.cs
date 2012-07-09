using System;
using System.Linq;
using Glass.Sitecore.Mapper;
using Sitecore.Data.Items;
using WebsiteKernel;

namespace DataObjects.Sitecore.ModelMapper
{
    internal abstract class ArticleDaoMapper : IArticleDaoMapper<Item>
    {
        protected ISitecoreContext SitecoreContext { get; set; }

        protected ArticleDaoMapper(ISitecoreContext sitecoreContext)
        {
            Guard.IsNotNull(() => sitecoreContext);
            SitecoreContext = sitecoreContext;
        }
        
        public abstract BusinessObjects.Article Map(Item item);

        public abstract Item Map(BusinessObjects.Article article);
    }
}
