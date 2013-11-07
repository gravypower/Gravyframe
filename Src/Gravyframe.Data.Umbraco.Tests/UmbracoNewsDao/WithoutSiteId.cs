namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    using Gravyframe.Configuration.Umbraco;
    using Gravyframe.Kernel.Umbraco.Tests;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;

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
    }
}
