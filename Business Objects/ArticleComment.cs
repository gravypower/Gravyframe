using BusinessObjects.Validators;
using FluentValidation;

namespace BusinessObjects
{
    public class ArticleComment : BusinessObject<ArticleComment>
    {
        public ArticleComment()
            : base(new ArticleCommentValidator())
        {
        }

         public ArticleComment(IValidator<ArticleComment> validator)
            : base(validator)
        {
        }

        public string Contents { get; set; }
    }
}
