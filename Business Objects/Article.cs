using System;
using BusinessObjects.Validators;
using FluentValidation;
using Glass.Sitecore.Mapper.Configuration;
using Glass.Sitecore.Mapper.Configuration.Attributes;

namespace BusinessObjects
{

    [SitecoreClass, Serializable]
    public class Article : BusinessObject<Article>
    {

        public Article():base(new ArticleValidator())
        {
        }

        public Article(IValidator<Article> validator)
            : base(validator)
        {
        }

        [SitecoreInfo(SitecoreInfoType.Name)]
        public virtual string Name { get; set; }

        [SitecoreField]
        public virtual string Title { get; set; }

        [SitecoreField]
        public virtual string Summary { get; set; }

        [SitecoreField("Article Body")]
        public virtual string ArticleBody { get; set; }

        //Still need to work out how I am going to do list of things
        //[SitecoreField("Related Article")]
        //public virtual string RelatedArticle { get; set; }

        [SitecoreField("Allow Comments")]
        public virtual bool AllowComments { get; set; }
    }
}
