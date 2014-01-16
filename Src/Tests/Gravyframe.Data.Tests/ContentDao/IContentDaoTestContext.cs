namespace Gravyframe.Data.Tests.ContentDao
{
    using Gravyframe.Data.Content;
    using Gravyframe.Models;

    public interface IContentDaoTestContext<TContent>
        where TContent : IContent
    {
        ContentDao<TContent> Sut { get; }

        string ExampleCategoryId { get; }

        string ExampleId { get; }

        string ExampleSiteId { get; }
    }
}
