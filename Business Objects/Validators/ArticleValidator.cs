using System;
using System.Linq;
using FluentValidation;

namespace BusinessObjects.Validators
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(article => article.ArticleBody).NotEmpty().WithMessage("An article needs a body");
        }
    }
}
