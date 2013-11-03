using Gravyframe.Configuration.Umbraco;
using Gravyframe.Kernel.Umbraco.Tests;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    public partial class UmbracoNewsDaoTests
    {
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
                    .AddProperty(UmbracoNewsConfiguration.DefaultListSizePropertyAlias, defaultListSize.ToString())
                    .Mock(2);


            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(mockNode);

            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryListIsDefaultSize();
            Assert.AreEqual(defaultListSize, Sut.NewsConfiguration.DefaultListSize);
        }
    }
}
