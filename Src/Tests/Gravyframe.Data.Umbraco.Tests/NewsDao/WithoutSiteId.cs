﻿namespace Gravyframe.Data.Umbraco.Tests.NewsDao
{
    using System.Linq;

    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    using NUnit.Framework;

    public class WithoutSiteIdTestContext : TestContext
    {
        public WithoutSiteIdTestContext()
        {
            var exampleId = int.Parse(this.ExampleId);
            var mockNode = new MockNode().Mock(exampleId);
            this.NodeFactoryFacade.GetNode(exampleId).Returns(mockNode);
        }
    }

    [TestFixture]
    public class And20NewsItems_WithoutSiteID : WithoutSiteID<UmbracoNews>
    {
        private WithoutSiteIdTestContext testContext;

        [SetUp]
        public void SetUp_And20NewsItems()
        {
            this.testContext = new WithoutSiteIdTestContext();
            this.testContext.MockNewsItemsInIndex();
            this.Context = this.testContext;
        }

        [Test]
        public void GetNewsByCategoryListDoesNotContainNewsForAnotherCategory()
        {
            // Assign
            var bodyText = "Test Body Text";

            var testCategoryIdOne = TestContext.TestCategoryId + "One";
            var testCategoryIdTwo = TestContext.TestCategoryId + "Two";

            var mockNode = new MockNode().AddProperty(News.NewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(TestContext.IndexType);
            var mnOne = mockNode.Mock();
            this.testContext.NodeFactoryFacade.GetNode(1).Returns(mnOne);
            mockDataSet.AddData(1, News.NewsDao.CategoriesAlias, testCategoryIdOne + "," + testCategoryIdTwo);

            this.testContext.MockedIndex.SimpleDataService.GetAllData(TestContext.IndexType).Returns(mockDataSet);

            this.testContext.MockedIndex.Indexer.RebuildIndex();

            // Act
            var resultOne = this.Context.Sut.GetNewsByCategoryId(testCategoryIdOne);
            var resultTwo = this.Context.Sut.GetNewsByCategoryId(testCategoryIdTwo);

            // Assert
            Assert.AreEqual(1, resultOne.Count());
            Assert.AreEqual(1, resultTwo.Count());
        }
    }
}
