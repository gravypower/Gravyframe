using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using Service.DataTransferObjects;
using WebsiteKernel.Mapping;
using WebsiteKernel;

namespace Service.Mappers
{
    public class DataTransferObjectsMapper : Service.Mappers.IDataTransferObjectsMapper
    {
        private readonly IMapper mapper;
        public DataTransferObjectsMapper(IMapper mapper)
        {
            Guard.IsNotNull(() => mapper);
            this.mapper = mapper;
        }

        public IList<ArticleDto> ToDataTransferObjects(IEnumerable<Article> articles)
        {
            return articles == null ? null : articles.Select(ToDataTransferObject).ToList();
        }

        public ArticleDto ToDataTransferObject(Article article)
        {
            if (article == null)
                return null;

            return mapper.Map<Article, ArticleDto>(article);
        }
    }
}
