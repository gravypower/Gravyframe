namespace Gravyframe.Data.Umbraco.Tests.NewsDao
{
    using Gravyframe.Configuration;
    using Gravyframe.Configuration.Umbraco;
    using Gravyframe.Data.News;
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine.MockIndex;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    public class TestContext : INewsDaoTestContext<UmbracoNews>
    {
        public INodeFactoryFacade NodeFactoryFacade;
        public MockedIndex MockedIndex;

        public const int NewsConfigurationNodeId = 1000;
        public const string IndexType = "News";
        public const string TestCategoryId = "TestCategoryId";

        public TestContext()
        {
            this.NodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            this.MockedIndex = MockIndexFactory.GetSimpleDataServiceMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList()
                    .AddIndexField(News.NewsDao.CategoriesAlias)
                    .AddIndexField(News.NewsDao.SiteIndexFieldName),
                new[] { IndexType },
                new string[] { },
                new string[] { });

            var newsConfiguration = new UmbracoNewsConfiguration(this.NodeFactoryFacade, NewsConfigurationNodeId);

            var defaultListSize = 20;

            var mockConfigurationNode =
                new MockNode().AddProperty(
                    UmbracoNewsConfiguration.DefaultListSizePropertyAlias,
                    defaultListSize.ToString()).Mock();

            this.NodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockConfigurationNode);

            this.Sut = new News.NewsDao(newsConfiguration, this.NodeFactoryFacade, this.MockedIndex.Searcher);
        }

        public class TestNewsConfiguration : NewsConfiguration
        {
        }

        public void MockNewsItemsInIndex(int numberToMock = 20, string site = "", string categoryId = TestCategoryId)
        {
            numberToMock = AdjustForLoop(numberToMock);

            var bodyText = "Test Body Text";

            var mockNode = new MockNode()
                .AddProperty(News.NewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(IndexType);
            for (var i = 1; i < numberToMock; i++)
            {
                var mn = mockNode.Mock(i);
                this.NodeFactoryFacade.GetNode(i).Returns(mn);
                mockDataSet.AddData(i, News.NewsDao.CategoriesAlias, categoryId);
                mockDataSet.AddData(i, News.NewsDao.SiteIndexFieldName, site);
            }

            this.MockedIndex.SimpleDataService.GetAllData(IndexType).Returns(mockDataSet);

            this.MockedIndex.Indexer.RebuildIndex();
        }

        private static int AdjustForLoop(int numberToMock)
        {
            return numberToMock + 1;
        }

        public NewsDao<UmbracoNews> Sut { get; private set; }

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
