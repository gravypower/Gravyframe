namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    using System.Linq;

    using NUnit.Framework;

    using Gravyframe.Models.Umbraco;

    using Kernel.Umbraco.Tests.TestHelpers;
    using Kernel.Umbraco.Tests.TestHelpers.Examine;

    using NSubstitute;

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
            testContext = new WithSiteIdTestContext();

            testContext.MockNewsItemsInIndex(site: testContext.ExampleSiteId);

            this.Context = testContext;
        }


        [Test]
        public void GetNewsByCategoryListForSiteDoesNotContainNewsForAnotherSite()
        {
            // Assign
            var siteOneName = "SiteOne";
            var siteTwoName = "SiteTwo";

            var bodyText = "Test Body Text";

            var mockNode = new MockNode().AddProperty(News.UmbracoNewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(TestContext.IndexType);
            var mnOne = mockNode.Mock();
            testContext.NodeFactoryFacade.GetNode(1).Returns(mnOne);
            mockDataSet.AddData(1, News.UmbracoNewsDao.CategoriesAlias, TestContext.TestCategoryId);
            mockDataSet.AddData(1, News.UmbracoNewsDao.Site, siteOneName);

            var mnTwo = mockNode.Mock(2);
            testContext.NodeFactoryFacade.GetNode(2).Returns(mnTwo);
            mockDataSet.AddData(2, News.UmbracoNewsDao.CategoriesAlias, TestContext.TestCategoryId);
            mockDataSet.AddData(2, News.UmbracoNewsDao.Site, siteTwoName);

            testContext.MockedIndex.SimpleDataService.GetAllData(TestContext.IndexType).Returns(mockDataSet);

            testContext.MockedIndex.Indexer.RebuildIndex();

            // Act
            var result = testContext.Sut.GetNewsByCategoryId(siteOneName, testContext.ExampleCategoryId);

            // Assert
            Assert.AreEqual(1, result.Count());

        }

    }
}
