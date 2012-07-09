using System;
namespace Service.Mappers
{
    public interface IDataTransferObjectsMapper
    {
        Service.DataTransferObjects.ArticleDto ToDataTransferObject(BusinessObjects.Article article);
        System.Collections.Generic.IList<Service.DataTransferObjects.ArticleDto> ToDataTransferObjects(System.Collections.Generic.IEnumerable<BusinessObjects.Article> articles);
    }
}
