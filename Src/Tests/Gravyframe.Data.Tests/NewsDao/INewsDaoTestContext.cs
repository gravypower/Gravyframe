using Gravyframe.Data.News;
namespace Gravyframe.Data.Tests.NewsDao
{
    public interface INewsDaoTestContext<TNews> 
        where TNews : Models.News
    {
        NewsDao<TNews> Sut { get; }

        string ExampleCategoryId { get; }

        string ExampleId { get; }

        string ExampleSiteId { get; }
    }
}
