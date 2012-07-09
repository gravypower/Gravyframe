using System.Collections.Generic;
using Service.DataTransferObjects;

namespace SitecoreClient.Repositories
{
    public interface IArticleRepository
    {
        IList<ArticleDto> GetArticles();
    }
}