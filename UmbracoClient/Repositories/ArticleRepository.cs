using System.Collections.Generic;
using System.ComponentModel;
using Service.DataTransferObjects;
using Service.ServiceContracts;
using Service.Messages;

namespace UmbracoClient.Repositories
{
    [DataObject(true)]
    public class ArticleRepository : RepositoryBase, IArticleRepository
    {
        private readonly IArticleService _articleService;
        public ArticleRepository(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<ArticleDto> GetArticles()
        {
            var request = new ArticleRequest();
            request.LoadOptions = new[] { "Articles" };
            request.ClientTag = "ABC123";
            var response = _articleService.GetArticles(request);

            Correlate(request, response);

            return response.Articles;

        }
    }
}