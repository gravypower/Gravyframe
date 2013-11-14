﻿using System.Linq;
using NSubstitute;
using NUnit.Framework;
using umbraco.interfaces;

namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    using Configuration;
    using Configuration.Umbraco;
    using Data.Tests.NewsDao;
    using Kernel.Umbraco.Facades;
    using Kernel.Umbraco.Tests.TestHelpers;
    using Kernel.Umbraco.Tests.TestHelpers.Examine;
    using Kernel.Umbraco.Tests.TestHelpers.Examine.MockIndex;
    using Models.Umbraco;

    [TestFixture]
    public partial class Tests : Tests<UmbracoNews>
    {
        [SetUp]
        public void SetUp()
        {
            _nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            _mockedIndex = MockIndexFactory.GetSimpleDataServiceMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList()
                    .AddIndexField(News.UmbracoNewsDao.CategoriesAlias)
                    .AddIndexField(News.UmbracoNewsDao.Site),
                new[] {IndexType},
                new string[] {},
                new string[] {});

            var newsConfiguration = new UmbracoNewsConfiguration(_nodeFactoryFacade, NewsConfigurationNodeId);
            Sut = new News.UmbracoNewsDao(newsConfiguration, _nodeFactoryFacade, _mockedIndex.Searcher);
        }

        private const int NewsConfigurationNodeId = 1000;
        private INodeFactoryFacade _nodeFactoryFacade;
        private MockedIndex _mockedIndex;

        private const string IndexType = "News";
        private const string TestCategoryId = "TestCategoryId";

        private class TestNewsConfiguration : NewsConfiguration
        {
        }

        private void MockNewsItemsInIndex(int numberToMock, string site = "", string categoryId = TestCategoryId)
        {
            numberToMock = AdjustForLoop(numberToMock);

            var bodyText = "Test Body Text";

            var mockNode = new MockNode()
                .AddProperty(News.UmbracoNewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(IndexType);
            for (int i = 1; i < numberToMock; i++)
            {
                var mn = mockNode.Mock(i);
                _nodeFactoryFacade.GetNode(i).Returns(mn);
                mockDataSet.AddData(i, News.UmbracoNewsDao.CategoriesAlias, categoryId);
                mockDataSet.AddData(i, News.UmbracoNewsDao.Site, site);
            }

            _mockedIndex.SimpleDataService.GetAllData(IndexType).Returns(mockDataSet);

            _mockedIndex.Indexer.RebuildIndex();
        }

        private static int AdjustForLoop(int numberToMock)
        {
            return numberToMock + 1;
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
        public void GetNewsFromUmbraco()
        {
            // Assign
            var mockNode = new MockNode()
                .AddProperty(News.UmbracoNewsDao.BodyAlias, "Test")
                .Mock();

            _nodeFactoryFacade.GetNode(1).Returns(mockNode);

            // Act
            var result = Sut.GetNews("1");

            // Assert
            Assert.AreEqual("Test", result.Body);
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
        public void WhenNewsConfigurationNodeIsNullDefaultListSize()
        {
            // Assign
            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(default(INode));
            var newsConfiguration = new TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, Sut.NewsConfiguration.DefaultListSize);
        }
    }
}