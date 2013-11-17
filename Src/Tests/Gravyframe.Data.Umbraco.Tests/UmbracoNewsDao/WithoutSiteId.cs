namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    using System.Linq;

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
    public class And20NewsItems_WithoutSiteID : Data.Tests.NewsDao.WithoutSiteID<UmbracoNews>
    {
        private WithoutSiteIdTestContext testContext;

        [SetUp]
        public void SetUp_And20NewsItems()
        {
            this.testContext = new WithoutSiteIdTestContext();
            this.testContext.MockNewsItemsInIndex();
            Context = this.testContext;
        }

        [Test]
        public void GetNewsByCategoryListDoesNotContainNewsForAnotherCategory()
        {
            // Assign
            var bodyText = "Test Body Text";

            var testCategoryIdOne = TestContext.TestCategoryId + "One";
            var testCategoryIdTwo = TestContext.TestCategoryId + "Two";

            var mockNode = new MockNode().AddProperty(News.UmbracoNewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(TestContext.IndexType);
            var mnOne = mockNode.Mock();
            testContext.NodeFactoryFacade.GetNode(1).Returns(mnOne);
            mockDataSet.AddData(1, News.UmbracoNewsDao.CategoriesAlias, testCategoryIdOne + "|" + testCategoryIdTwo);

            testContext.MockedIndex.SimpleDataService.GetAllData(TestContext.IndexType).Returns(mockDataSet);

            testContext.MockedIndex.Indexer.RebuildIndex();

            // Act
            var resultOne = Context.Sut.GetNewsByCategoryId(testCategoryIdOne);
            var resultTwo = Context.Sut.GetNewsByCategoryId(testCategoryIdTwo);

            // Assert
            Assert.AreEqual(1, resultOne.Count());
            Assert.AreEqual(1, resultTwo.Count());
        }
    }
}
