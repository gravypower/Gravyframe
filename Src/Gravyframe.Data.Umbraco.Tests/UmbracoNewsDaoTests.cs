﻿using System.Linq;
using Gravyframe.Configuration;
using Gravyframe.Configuration.Umbraco;
using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Tests;
using Gravyframe.Kernel.Umbraco.Tests.Examine;
using Gravyframe.Models.Umbraco;
using NSubstitute;
using NUnit.Framework;
using Gravyframe.Kernel.Umbraco.Facades;

namespace Gravyframe.Data.Umbraco.Tests
{
    [TestFixture]
    public class UmbracoNewsDaoTests : NewsDaoTests<UmbracoNews>
    {
        private const int NewsConfigurationNodeId = 1000;
        private INodeFactoryFacade _nodeFactoryFacade;
        private MockedIndex _mockedIndex;

        private const string IndexType = "News";
        private const string TestCategoryId = "TestCategoryId";

        private void MockNewsItemsInIndex(int numberToMock)
        {
            numberToMock = AdjustForLoop(numberToMock);

            var bodyText = "Test Body Text";

            var mockNode = new MockNode()
                .AddProperty(UmbracoNewsDao.BodyAlias, bodyText)
                .Mock();

            var mockDataSet = new MockSimpleDataSet(IndexType);
            for (var i = 1; i < numberToMock; i++)
            {
                _nodeFactoryFacade.GetNode(i).Returns(mockNode);
                mockDataSet.AddData(i, UmbracoNewsDao.CategoriesAlias, TestCategoryId);
            }

            _mockedIndex.SimpleDataService.GetAllData("News").Returns(mockDataSet);

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
            _mockedIndex = MockIndexFactory.GetMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList().AddIndexField(UmbracoNewsDao.CategoriesAlias),
                new[] { IndexType },
                new string[] { },
                new string[] { });


            var newsConfiguration = new UmbracoNewsConfiguration(_nodeFactoryFacade, NewsConfigurationNodeId);
            Sut = new UmbracoNewsDao(newsConfiguration, _nodeFactoryFacade, _mockedIndex.Searcher);
        }

        [Test]
        public void GetNewsFromUmbraco()
        {
            // Assign
            var mockNode = new MockNode()
                .AddProperty(UmbracoNewsDao.BodyAlias, "Test")
                .Mock();
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
        public override void GetNewByCategoryWithCustomListSize()
        {
            // Assign
            MockNewsItemsInIndex(10);

            base.GetNewByCategoryWithCustomListSize();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeFirstPage()
        {
            // Assign
            MockNewsItemsInIndex(10);

            base.GetNewsByCategoryIdCustomListSizeFirstPage();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeForthPage()
        {
            // Assign
            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeForthPage();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeSecondPage()
        {
            // Assign
            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeSecondPage();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeThirdPage()
        {
            // Assign
            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeThirdPage();
        }

        [Test]
        public override void GetNewsByCategoryListIsDefaultSize()
        {
            // Assign
            var defaultListSize = 20;

            var mockNode = new MockNode()
                    .AddProperty(UmbracoNewsConfiguration.DefaultListSizePropertyAlias,defaultListSize.ToString())
                    .Mock();


            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockNode);

            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryListIsDefaultSize();
            Assert.AreEqual(defaultListSize, Sut.NewsConfiguration.DefaultListSize);
        }

        [Test]
        public void GetNewsByCategoryListIsDefaultSize1()
        {
            // Assign
            var mockNode = new MockNode().Mock();
            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockNode);

            //Assert
            Assert.AreEqual(new NewsConfiguration().DefaultListSize, Sut.NewsConfiguration.DefaultListSize);
        }

        //[Test]
        //public void Can

        protected override string GetExampleId()
        {
            return "1";
        }

        protected override string GetExampleCategoryId()
        {
            return TestCategoryId;
        }
    }
}
