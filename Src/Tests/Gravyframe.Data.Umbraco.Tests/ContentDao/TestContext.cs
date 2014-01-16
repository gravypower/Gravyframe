namespace Gravyframe.Data.Umbraco.Tests.ContentDao
{
    using Gravyframe.Configuration.Umbraco;
    using Gravyframe.Data.Tests.ContentDao;
    using Gravyframe.Data.Umbraco.Content;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine.MockIndex;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    public class TestContext : IContentDaoTestContext<Content>
    {
        public Data.Content.ContentDao<Content> Sut { get; private set; }

        public const int ContentConfigurationNodeId = 1000;
        public const string IndexType = "Content";
        public const string TestCategoryId = "TestCategoryId";
        public INodeFactoryFacade NodeFactoryFacade;
        public MockedIndex MockedIndex;

        public TestContext()
        {
            this.NodeFactoryFacade = Substitute.For<INodeFactoryFacade>();

            this.MockedIndex = MockIndexFactory.GetSimpleDataServiceMock(
               new MockIndexFieldList().AddIndexField("id", "Number", true),
               new MockIndexFieldList()
                   .AddIndexField(ContentDao.CategoriesAlias)
                   .AddIndexField(ContentDao.SiteIndexFieldName),
               new[] { IndexType },
               new string[] { },
               new string[] { });

            var contentConfiguration = new ContentConfiguration(this.NodeFactoryFacade, ContentConfigurationNodeId);

            var defaultListSize = 20;

            var mockConfigurationNode =
               new MockNode().AddProperty(
                   ContentConfiguration.DefaultListSizePropertyAlias,
                   defaultListSize.ToString()).Mock();

            this.NodeFactoryFacade.GetNode(ContentConfigurationNodeId).Returns(mockConfigurationNode);

            this.Sut = new ContentDao(this.NodeFactoryFacade, contentConfiguration, this.MockedIndex.Searcher);
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
                mockDataSet.AddData(i, ContentDao.CategoriesAlias, categoryId);
                mockDataSet.AddData(i, ContentDao.SiteIndexFieldName, site);
            }

            this.MockedIndex.SimpleDataService.GetAllData(IndexType).Returns(mockDataSet);

            this.MockedIndex.Indexer.RebuildIndex();
        }

        private static int AdjustForLoop(int numberToMock)
        {
            return numberToMock + 1;
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
