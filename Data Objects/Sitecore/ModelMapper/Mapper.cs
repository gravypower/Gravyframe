using System;
using System.Linq;
using Sitecore.Data.Items;
using Glass.Sitecore.Mapper;
using BusinessObjects;

namespace DataObjects.Sitecore.ModelMapper
{
    internal class Mapper : ArticleDaoMapper, IArticleDaoMapper<Item>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mapper"/> class.
        /// </summary>
        /// <param name="sitecoreContext">The sitecore context.</param>
        public Mapper(ISitecoreContext sitecoreContext):base(sitecoreContext)
        {
        }

        public override Article Map(Item item)
        {
            return SitecoreContext.GetItem<Article>(item.ID.Guid);
        }

        public override Item Map(Article article)
        {
            throw new NotImplementedException("Still need to work out I am going to pass changes back to Sitecore");
        }
    }
}
