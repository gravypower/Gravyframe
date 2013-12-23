namespace Gravyframe.Data.EPiServer.Tests.EPiServerNewsDao
{
    using global::EPiServer;

    using Gravyframe.Data.News;
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Models.EPiServer;

    using NSubstitute;

    public class TestContext : INewsDaoTestContext<EPiServerNews>
    {
        public NewsDao<EPiServerNews> Sut { get; private set; }

        public IContentRepository ContentRepository;

        public const int NewsConfigurationNodeId = 1000;
        public const string TestCategoryId = "TestCategoryId";

        public TestContext()
        {
            this.ContentRepository = Substitute.For<IContentRepository>();
            Sut = new News.EPiServerNewsDao(ContentRepository);
        }

        public string ExampleCategoryId
        {
            get
            {
                return TestCategoryId;
            }
        }

        public string ExampleId
        {
            get
            {
                return "{F8F5F574-4D7A-4769-93D9-9836BA144D9A}";
            }
        }

        public string ExampleSiteId
        {
            get
            {
                return TestCategoryId;
            }
        }
    }
}
