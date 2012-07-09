using System;
using System.Linq;
using FluentValidation;

namespace BusinessObjects.Validators
{
    public class ArticleCommentValidator : AbstractValidator<ArticleComment>
    {
        public ArticleCommentValidator()
        {
            RuleFor(articleComment => articleComment.Contents).NotEmpty().WithMessage(
                "Must have contents in an Article Comment");
        }
    }
}
