using Gravyframe.Configuration.Umbraco;
using Gravyframe.Kernel.Umbraco.Tests;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    public partial class UmbracoNewsDaoTests
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

            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryListIsDefaultSizeWithSiteId();
            Assert.AreEqual(defaultListSize, Sut.NewsConfiguration.DefaultListSize);
        }
    }
}
