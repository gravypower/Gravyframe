namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    using System.Linq;
    using Configuration.Umbraco;
    using Kernel.Umbraco.Tests.TestHelpers;
    using Kernel.Umbraco.Tests.TestHelpers.Examine;

    using NSubstitute;

    using NUnit.Framework;

    public partial class Tests
    {
        [Test]
        public override void GetNewByCategoryWithCustomListSizeWithSiteId()
        {
            // Assign
            MockNewsItemsInIndex(10);

            base.GetNewByCategoryWithCustomListSizeWithSiteId();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeFirstPageWithSiteId()
        {
            // Assign
            MockNewsItemsInIndex(10);

            base.GetNewsByCategoryIdCustomListSizeFirstPageWithSiteId();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeForthPageWithSiteId()
        {
            // Assign
            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeForthPageWithSiteId();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeSecondPageWithSiteId()
        {
            // Assign
            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeSecondPage();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeThirdPageWithSiteId()
        {
            // Assign
            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeThirdPage();
        }

        [Test]
        public override void GetNewsByCategoryListIsDefaultSizeWithSiteId()
        {
            // Assign
            var defaultListSize = 20;
            var mockNode = new MockNode()
                    .AddProperty(UmbracoNewsConfiguration.DefaultListSizePropertyAlias, defaultListSize.ToString())
                    .Mock(2);


            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockNode);

            MockNewsItemsInIndex(20, GetExampleSiteId());

            base.GetNewsByCategoryListIsDefaultSizeWithSiteId();
            Assert.AreEqual(defaultListSize, Sut.NewsConfiguration.DefaultListSize);
        }

        [Test]
        public void GetNewsByCategoryListForSiteDoesNotContainNewsForAnotherSite()
        {
            // Assign
            var siteOneName = "SiteOne";
            var siteTwoName = "SiteTwo";

            var bodyText = "Test Body Text";

            var mockNode = new MockNode()
                .AddProperty(News.UmbracoNewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(IndexType);
            var mnOne = mockNode.Mock(1);
            _nodeFactoryFacade.GetNode(1).Returns(mnOne);
            mockDataSet.AddData(1, News.UmbracoNewsDao.CategoriesAlias, TestCategoryId);
            mockDataSet.AddData(1, News.UmbracoNewsDao.Site, siteOneName);

            var mnTwo = mockNode.Mock(2);
            _nodeFactoryFacade.GetNode(2).Returns(mnTwo);
            mockDataSet.AddData(2, News.UmbracoNewsDao.CategoriesAlias, TestCategoryId);
            mockDataSet.AddData(2, News.UmbracoNewsDao.Site, siteTwoName);
            
            _mockedIndex.SimpleDataService.GetAllData(IndexType).Returns(mockDataSet);

            _mockedIndex.Indexer.RebuildIndex();

            var categoryId = GetExampleCategoryId();

            // Act
            var result = Sut.GetNewsByCategoryId(siteOneName, categoryId);

            // Assert
            Assert.AreEqual(1, result.Count());

        }
    }
}
