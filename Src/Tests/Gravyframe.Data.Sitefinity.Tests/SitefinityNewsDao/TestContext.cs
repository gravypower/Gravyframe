namespace Gravyframe.Data.Sitefinity.Tests.SitefinityNewsDao
{
    using Gravyframe.Data.News;
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Kernel.Sitefinity.Facades;
    using Gravyframe.Models.Sitefinity;

    using NSubstitute;

    public class TestContext : INewsDaoTestContext<SitefinityNews>
    {
        public const int NewsConfigurationNodeId = 1000;
        public const string IndexType = "News";
        public const string TestCategoryId = "TestCategoryId";

        public INewsDataProviderFacade NewsDataProviderFacade;

        public TestContext()
        {
            this.NewsDataProviderFacade = Substitute.For<INewsDataProviderFacade>();
            Sut = new News.SitefinityNewsDao(NewsDataProviderFacade);
        }

        public NewsDao<SitefinityNews> Sut { get; private set; }

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
                return "2";
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
