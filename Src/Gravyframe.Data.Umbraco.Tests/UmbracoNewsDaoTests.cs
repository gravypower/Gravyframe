using System.Collections.Generic;
using System.Linq;
using Gravyframe.Constants;
using Gravyframe.Constants.Umbraco;
using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco;
using Gravyframe.Kernel.Umbraco.Tests;
using Gravyframe.Kernel.Umbraco.Tests.Examine;
using Gravyframe.Models.Umbraco;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Data.Umbraco.Tests
{
    [TestFixture]
    public class UmbracoNewsDaoTests : NewsDaoTests<UmbracoNews>
    {
        private const int NewsConfigurationNodeId = 1000;
        private INodeFactoryFacade _nodeFactoryFacade;
        private MockedIndex _mockedIndex;

        private const string IndexType = "News";
        private const string IndexFieldName = "categoryId";

        private void MockNewsItemsInIndex(int numberToMock)
        {
            numberToMock = AdjustForLoop(numberToMock);

            var bodyText = "Test Body Text";
            var node = MockNodeFactory.BuildNode(new Dictionary<string, object> { { "Body", bodyText } });

            var mockDataSet = new MockSimpleDataSet(IndexType);
            for (var i = 1; i < numberToMock; i++)
            {
                _nodeFactoryFacade.GetNode(i).Returns(node);
                mockDataSet.AddData(i, IndexFieldName, "categoryId");
            }

            _mockedIndex.SimpleDataService.GetAllData("News").Returns(mockDataSet);

            _mockedIndex.Indexer.RebuildIndex();
        }

        private static int AdjustForLoop(int numberToMock)
        {
            return numberToMock + 1;
        }

        [SetUp]
        public void SetUp()
        {
            _nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            _mockedIndex = MockIndexFactory.GetMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList().AddIndexField(IndexFieldName),
                new[] { IndexType },
                new string[] { },
                new string[] { });

            Sut = new UmbracoNewsDao(NewsConfigurationNodeId, _nodeFactoryFacade, _mockedIndex.Searcher);
        }

        [Test]
        public void GetNewsFromUmbraco()
        {
            // Assign
            var node = MockNodeFactory.BuildNode(new Dictionary<string, object> {{"Body", "Test"}});
            _nodeFactoryFacade.GetNode(1).Returns(node);

            // Act
            var result = Sut.GetNews("1");

            // Assert
            Assert.AreEqual("Test", result.Body);
        }


        [Test]
        public void GetNewsByCategoryIdFromUmbracoExamineIndex()
        {
            // Assign
            MockNewsItemsInIndex(1);

            // Act
            var result = Sut.GetNewsByCategoryId("categoryId");

            // Assert
            Assert.IsTrue(result.Any());
        }

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
            var node =
                MockNodeFactory.BuildNode(
                    new Dictionary<string, object>
                        {
                            {
                                UmbracoNewsConstants.DefaultListSizePropertyAlias,
                                defaultListSize.ToString()
                            }
                        });

            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(node);

            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryListIsDefaultSize();
            Assert.AreEqual(defaultListSize, Sut.NewsConstants.DefaultListSize);
        }

        [Test]
        public void GetNewsByCategoryListIsDefaultSi()
        {
            // Assign
            var node = MockNodeFactory.BuildNode(new Dictionary<string, object> ());
            _nodeFactoryFacade.GetNode(NewsConfigurationNodeId).Returns(node);
            MockNewsItemsInIndex(20);

            base.GetNewsByCategoryListIsDefaultSize();

            Assert.AreEqual(new NewsConstants().DefaultListSize, Sut.NewsConstants.DefaultListSize);
        }

        protected override string GetExampleId()
        {
            return "1";
        }

        protected override string GetExampleCategoryId()
        {
            return IndexFieldName;
        }
    }
}
