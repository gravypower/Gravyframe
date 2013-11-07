namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    using System.Linq;

    using Gravyframe.Configuration;
    using Gravyframe.Configuration.Umbraco;
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine.MockIndex;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    using NUnit.Framework;

    using umbraco.interfaces;

    [TestFixture]
    public partial class Tests : Tests<UmbracoNews>
    {
        private const int NewsConfigurationNodeId = 1000;
        private INodeFactoryFacade _nodeFactoryFacade;
        private MockedIndex _mockedIndex;

        private const string IndexType = "News";
        private const string TestCategoryId = "TestCategoryId";

        private class TestNewsConfiguration : NewsConfiguration { }

        private void MockNewsItemsInIndex(int numberToMock, string site = "")
        {
            numberToMock = AdjustForLoop(numberToMock);

            var bodyText = "Test Body Text";

            var mockNode = new MockNode()
                .AddProperty(Umbraco.News.UmbracoNewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(IndexType);
            for (var i = 1; i < numberToMock; i++)
            {
                var mn = mockNode.Mock(i);
                this._nodeFactoryFacade.GetNode(i).Returns(mn);
                mockDataSet.AddData(i, Umbraco.News.UmbracoNewsDao.CategoriesAlias, TestCategoryId);
                mockDataSet.AddData(i, Umbraco.News.UmbracoNewsDao.Site, site);
            }

            this._mockedIndex.SimpleDataService.GetAllData(IndexType).Returns(mockDataSet);

            this._mockedIndex.Indexer.RebuildIndex();
        }

        private static int AdjustForLoop(int numberToMock)
        {
            return numberToMock + 1;
        }

        [SetUp]
        public void SetUp()
        {
            this._nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            this._mockedIndex = MockIndexFactory.GetSimpleDataServiceMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList()
                    .AddIndexField(Umbraco.News.UmbracoNewsDao.CategoriesAlias)
                    .AddIndexField(Umbraco.News.UmbracoNewsDao.Site),
                new[] { IndexType },
                new string[] { },
                new string[] { });

            var newsConfiguration = new UmbracoNewsConfiguration(this._nodeFactoryFacade, NewsConfigurationNodeId);
            this.Sut = new Umbraco.News.UmbracoNewsDao(newsConfiguration, this._nodeFactoryFacade, this._mockedIndex.Searcher);
        }

        [Test]
        public void GetNullNewsFromUmbraco()
        {
            this._nodeFactoryFacade.GetNode(1).Returns(default(INode));

            // Act
            var result = this.Sut.GetNews("1");

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void GetNewsFromUmbraco()
        {
            // Assign
            var mockNode = new MockNode()
                .AddProperty(Umbraco.News.UmbracoNewsDao.BodyAlias, "Test")
                .Mock(1);
            this._nodeFactoryFacade.GetNode(1).Returns(mockNode);

            // Act
            var result = this.Sut.GetNews("1");

            // Assert
            Assert.AreEqual("Test", result.Body);
        }


        [Test]
        public void GetNewsByCategoryIdFromUmbracoExamineIndex()
        {
            // Assign
            this.MockNewsItemsInIndex(1);

            // Act
            var result = this.Sut.GetNewsByCategoryId(TestCategoryId);

            // Assert
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetNewsByCategoryListIsDefaultSize1()
        {

            // Assign
            var mockNode = new MockNode().Mock(2);
            this._nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockNode);
            var newsConfiguration = new TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, this.Sut.NewsConfiguration.DefaultListSize);
        }

        [Test]
        public void WhenNewsConfigurationNodeIsNullDefaultListSize()
        {
            // Assign
            this._nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(default(INode));
            var newsConfiguration = new TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, this.Sut.NewsConfiguration.DefaultListSize);
        }

        protected override string GetExampleId()
        {
            return "1";
        }

        protected override string GetExampleCategoryId()
        {
            return TestCategoryId;
        }

        protected override void MockExampleNode()
        {
            var exampleId = int.Parse(this.GetExampleId());
            var mockNode = new MockNode().Mock(exampleId);
            this._nodeFactoryFacade.GetNode(exampleId).Returns(mockNode);
        }

        protected override string GetExampleSiteId()
        {
            return "UmbracoSite";
        }
    }
}
