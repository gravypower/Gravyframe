using System.Collections.Generic;
using System.Linq;
using Examine;
using Examine.LuceneEngine;
using Examine.LuceneEngine.Providers;
using Gravyframe.Constants;
using Gravyframe.Constants.Umbraco;
using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco;
using Gravyframe.Kernel.Umbraco.Tests;
using Gravyframe.Kernel.Umbraco.Tests.Examine;
using Gravyframe.Models.Umbraco;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using NSubstitute;
using NUnit.Framework;
using UmbracoExamine;

namespace Gravyframe.Data.Umbraco.Tests
{
    [TestFixture]
    public class UmbracoNewsDaoTests : NewsDaoTests<UmbracoNews>
    {
        private const int NewsConfigurationNodeId = 1000;
        private INodeFactoryFacade _nodeFactoryFacade;
        private ISearcher _searcher;
        private IIndexer _indexer;
        private ISimpleDataService _simpleDataService;

        private void MockIndex()
        {
            _simpleDataService = Substitute.For<ISimpleDataService>();

            var standFields = new MockIndexFieldList()
                .AddIndexField("id", "Number", true);

            var userFields = new MockIndexFieldList()
                .AddIndexField("categoryId");

            var indexTypes = new[] {"News"};
            var includeNodeTypes = new string[] {};
            var excludeNodeTypes = new string[] {};

            var luceneDir = new RAMDirectory();
            var indexCriteria = new IndexCriteria(standFields, userFields, includeNodeTypes, excludeNodeTypes, -1);
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);

            _indexer = new SimpleDataIndexer(indexCriteria, luceneDir, analyzer, _simpleDataService, indexTypes, false);

            _searcher = new UmbracoExamineSearcher(luceneDir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
        }

        private void MockNewsItemsInIndex(int numberToMock)
        {
            numberToMock = AdjustForLoop(numberToMock);

            var bodyText = "Test Body Text";
            var node = MockNodeFactory.BuildNode(new Dictionary<string, object> { { "Body", bodyText } });

            var mockDataSet = new MockSimpleDataSet("News");
            for (var i = 1; i < numberToMock; i++)
            {
                _nodeFactoryFacade.GetNode(i).Returns(node);
                mockDataSet.AddData(i, "categoryId", "categoryId");
            }

            _simpleDataService.GetAllData("News").Returns(mockDataSet);

            _indexer.RebuildIndex();
        }

        private static int AdjustForLoop(int numberToMock)
        {
            return numberToMock + 1;
        }

        [SetUp]
        public void SetUp()
        {
            _nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            MockIndex();
            Sut = new UmbracoNewsDao(NewsConfigurationNodeId, _nodeFactoryFacade, _searcher);
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
    }
}
