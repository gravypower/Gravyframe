namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    using System.Linq;
    using Gravyframe.Configuration.Umbraco;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine;

    using NSubstitute;

    using NUnit.Framework;

    public partial class Tests
    {
        [Test]
        public override void GetNewByCategoryWithCustomListSizeWithSiteId()
        {
            // Assign
            this.MockNewsItemsInIndex(10);

            base.GetNewByCategoryWithCustomListSizeWithSiteId();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeFirstPageWithSiteId()
        {
            // Assign
            this.MockNewsItemsInIndex(10);

            base.GetNewsByCategoryIdCustomListSizeFirstPageWithSiteId();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeForthPageWithSiteId()
        {
            // Assign
            this.MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeForthPageWithSiteId();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeSecondPageWithSiteId()
        {
            // Assign
            this.MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeSecondPage();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeThirdPageWithSiteId()
        {
            // Assign
            this.MockNewsItemsInIndex(20);

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


            this._nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockNode);

            this.MockNewsItemsInIndex(20, site: this.GetExampleSiteId());

            base.GetNewsByCategoryListIsDefaultSizeWithSiteId();
            Assert.AreEqual(defaultListSize, this.Sut.NewsConfiguration.DefaultListSize);
        }

        [Test]
        public void GetNewsByCategoryListForSiteDoesNotContainNewsForAnotherSite()
        {
            // Assign
            var siteOneName = "SiteOne";
            var siteTwoName = "SiteTwo";

            var bodyText = "Test Body Text";

            var mockNode = new MockNode()
                .AddProperty(Umbraco.News.UmbracoNewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(IndexType);
            var mnOne = mockNode.Mock(1);
            this._nodeFactoryFacade.GetNode(1).Returns(mnOne);
            mockDataSet.AddData(1, Umbraco.News.UmbracoNewsDao.CategoriesAlias, TestCategoryId);
            mockDataSet.AddData(1, Umbraco.News.UmbracoNewsDao.Site, siteOneName);

            var mnTwo = mockNode.Mock(2);
            this._nodeFactoryFacade.GetNode(2).Returns(mnTwo);
            mockDataSet.AddData(2, Umbraco.News.UmbracoNewsDao.CategoriesAlias, TestCategoryId);
            mockDataSet.AddData(2, Umbraco.News.UmbracoNewsDao.Site, siteTwoName);
            
            this._mockedIndex.SimpleDataService.GetAllData(IndexType).Returns(mockDataSet);

            this._mockedIndex.Indexer.RebuildIndex();

            var categoryId = this.GetExampleCategoryId();

            // Act
            var result = this.Sut.GetNewsByCategoryId(siteOneName, categoryId);

            // Assert
            Assert.AreEqual(1, result.Count());

        }
    }
}
