using System.Linq;
using Gravyframe.Configuration;
using Gravyframe.Configuration.Umbraco;
using Gravyframe.Data.Tests.NewsDao;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Kernel.Umbraco.Tests;
using Gravyframe.Models.Umbraco;
using NSubstitute;
using NUnit.Framework;
using umbraco.interfaces;
using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers;
using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockIndex;

namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    [TestFixture]
    public partial class UmbracoNewsDaoTests : NewsDaoTests<UmbracoNews>
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
                .AddProperty(News.UmbracoNewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(IndexType);
            for (var i = 1; i < numberToMock; i++)
            {
                var mn = mockNode.Mock(i);
                _nodeFactoryFacade.GetNode(i).Returns(mn);
                mockDataSet.AddData(i, News.UmbracoNewsDao.CategoriesAlias, TestCategoryId);
                mockDataSet.AddData(i, News.UmbracoNewsDao.Site, site);
            }

            _mockedIndex.SimpleDataService.GetAllData(IndexType).Returns(mockDataSet);

            _mockedIndex.Indexer.RebuildIndex();
        }

        private static int AdjustForLoop(int numberToMock)
        {
            return numberToMock + 1;
        }

        [SetUp]
        public void SetUp()
        {
            _nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            _mockedIndex = MockIndexFactory.GetSimpleDataServiceMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList()
                    .AddIndexField(News.UmbracoNewsDao.CategoriesAlias)
                    .AddIndexField(News.UmbracoNewsDao.Site),
                new[] { IndexType },
                new string[] { },
                new string[] { });


            var newsConfiguration = new UmbracoNewsConfiguration(_nodeFactoryFacade, NewsConfigurationNodeId);
            Sut = new News.UmbracoNewsDao(newsConfiguration, _nodeFactoryFacade, _mockedIndex.Searcher);
        }

        [Test]
        public void GetNullNewsFromUmbraco()
        {
            _nodeFactoryFacade.GetNode(1).Returns(default(INode));

            // Act
            var result = Sut.GetNews("1");

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void GetNewsFromUmbraco()
        {
            // Assign
            var mockNode = new MockNode()
                .AddProperty(News.UmbracoNewsDao.BodyAlias, "Test")
                .Mock(1);
            _nodeFactoryFacade.GetNode(1).Returns(mockNode);

            // Act
            var result = Sut.GetNews("1");

            // Assert
            Assert.AreEqual("Test", result.Body);
        }


        [Test]
        public void GetNewsByCategoryIdFromUmbracoExamineIndex()
        {
            // Assign
            MockNewsItemsInIndex(1);

            // Act
            var result = Sut.GetNewsByCategoryId(TestCategoryId);

            // Assert
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetNewsByCategoryListIsDefaultSize1()
        {

            // Assign
            var mockNode = new MockNode().Mock(2);
            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockNode);
            var newsConfiguration = new TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, Sut.NewsConfiguration.DefaultListSize);
        }

        [Test]
        public void WhenNewsConfigurationNodeIsNullDefaultListSize()
        {
            // Assign
            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(default(INode));
            var newsConfiguration = new TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, Sut.NewsConfiguration.DefaultListSize);
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
            var exampleId = int.Parse(GetExampleId());
            var mockNode = new MockNode().Mock(exampleId);
            _nodeFactoryFacade.GetNode(exampleId).Returns(mockNode);
        }

        protected override string GetExampleSiteId()
        {
            return "UmbracoSite";
        }
    }
}
