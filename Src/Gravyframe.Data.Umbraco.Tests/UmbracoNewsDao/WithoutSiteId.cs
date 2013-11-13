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
        public override void GetNewByCategoryWithCustomListSize()
        {
            // Assign
            this.MockNewsItemsInIndex(10);

            base.GetNewByCategoryWithCustomListSize();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeFirstPage()
        {
            // Assign
            this.MockNewsItemsInIndex(10);

            base.GetNewsByCategoryIdCustomListSizeFirstPage();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeForthPage()
        {
            // Assign
            this.MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeForthPage();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeSecondPage()
        {
            // Assign
            this.MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeSecondPage();
        }

        [Test]
        public override void GetNewsByCategoryIdCustomListSizeThirdPage()
        {
            // Assign
            this.MockNewsItemsInIndex(20);

            base.GetNewsByCategoryIdCustomListSizeThirdPage();
        }

        [Test]
        public override void GetNewsByCategoryListIsDefaultSize()
        {
            // Assign
            var defaultListSize = 20;

            var mockNode = new MockNode()
                    .AddProperty(UmbracoNewsConfiguration.DefaultListSizePropertyAlias, defaultListSize.ToString())
                    .Mock(2);


            this._nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockNode);

            this.MockNewsItemsInIndex(20);

            base.GetNewsByCategoryListIsDefaultSize();
            Assert.AreEqual(defaultListSize, this.Sut.NewsConfiguration.DefaultListSize);
        }

        [Test]
        public void someTest()
        {
            // Assign
            var bodyText = "Test Body Text";

            var testCategoryIdOne = TestCategoryId + "One";
            var testCategoryIdTwo = TestCategoryId + "Two";

            var mockNode = new MockNode()
                .AddProperty(News.UmbracoNewsDao.BodyAlias, bodyText);

            var mockDataSet = new MockSimpleDataSet(IndexType);
            var mnOne = mockNode.Mock();
            _nodeFactoryFacade.GetNode(1).Returns(mnOne);
            mockDataSet.AddData(1, News.UmbracoNewsDao.CategoriesAlias, testCategoryIdOne + "|" + testCategoryIdTwo);


            _mockedIndex.SimpleDataService.GetAllData(IndexType).Returns(mockDataSet);

            _mockedIndex.Indexer.RebuildIndex();

            // Act
            var resultOne = Sut.GetNewsByCategoryId(testCategoryIdOne);
            var resultTwo = Sut.GetNewsByCategoryId(testCategoryIdTwo);

            // Assert
            Assert.AreEqual(1, resultOne.Count());
            Assert.AreEqual(1, resultTwo.Count());
        }
    }
}
