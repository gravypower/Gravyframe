using System.Collections.Generic;
using Service.DataTransferObjects;

namespace UmbracoClient.Repositories
{
    public interface IArticleRepository
    {
        IList<ArticleDto> GetArticles();
    }
}