namespace Gravyframe.Data.Umbraco.Tests.NewsDao
{
    using System.Linq;

    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    using NUnit.Framework;

    public class WithSiteIdTestContext : TestContext
    {
        public WithSiteIdTestContext()
        {
            var exampleId = int.Parse(this.ExampleId);
            var mockNode = new MockNode().Mock(exampleId);
            this.NodeFactoryFacade.GetNode(exampleId).Returns(mockNode);
        }
    }

    [TestFixture]
    public class And20NewsItems_WithSiteId : Data.Tests.NewsDao.WithSiteID<UmbracoNews>
    {
        private WithSiteIdTestContext testContext;

        [SetUp]
        public void SetUp_And20NewsItems()
        {
            this.testContext = new WithSiteIdTestContext();

            this.testContext.MockNewsItemsInIndex(site: this.testContext.ExampleSiteId);

            this.Context = this.testContext;
        }


        [Test]
        public void GetNewsByCategoryListForSiteDoesNotContainNewsForAnotherSite()
        {
            // Assign
            var siteOneName = "SiteOne";
            var siteTwoName = "SiteTwo";

            var bodyText = "Test Body Text";

            var mockNode = new MockNode().AddProperty(News.NewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(TestContext.IndexType);
            var mnOne = mockNode.Mock();
            this.testContext.NodeFactoryFacade.GetNode(1).Returns(mnOne);
            mockDataSet.AddData(1, News.NewsDao.CategoriesAlias, TestContext.TestCategoryId);
            mockDataSet.AddData(1, News.NewsDao.SiteIndexFieldName, siteOneName);

            var mnTwo = mockNode.Mock(2);
            this.testContext.NodeFactoryFacade.GetNode(2).Returns(mnTwo);
            mockDataSet.AddData(2, News.NewsDao.CategoriesAlias, TestContext.TestCategoryId);
            mockDataSet.AddData(2, News.NewsDao.SiteIndexFieldName, siteTwoName);

            this.testContext.MockedIndex.SimpleDataService.GetAllData(TestContext.IndexType).Returns(mockDataSet);

            this.testContext.MockedIndex.Indexer.RebuildIndex();

            // Act
            var result = this.testContext.Sut.GetNewsByCategoryId(siteOneName, this.testContext.ExampleCategoryId);

            // Assert
            Assert.AreEqual(1, result.Count());

        }

    }
}
