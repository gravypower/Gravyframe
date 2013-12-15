using Gravyframe.Data.News;
namespace Gravyframe.Data.Tests.NewsDao
{
    using Gravyframe.Models;

    public interface INewsDaoTestContext<TNews>
        where TNews : INews
    {
        NewsDao<TNews> Sut { get; }

        string ExampleCategoryId { get; }

        string ExampleId { get; }

        string ExampleSiteId { get; }
    }
}
