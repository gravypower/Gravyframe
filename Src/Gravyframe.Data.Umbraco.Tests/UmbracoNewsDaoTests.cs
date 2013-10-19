using System.Collections.Generic;
using System.Xml.Linq;
using Examine;
using Examine.LuceneEngine;
using Examine.LuceneEngine.Providers;
using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco;
using Gravyframe.Kernel.Umbraco.Tests;
using Lucene.Net.Documents;
using NSubstitute;
using NUnit.Framework;
using UmbracoExamine;
using umbraco.interfaces;
using UmbracoExamine.DataServices;
using System.Linq;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace Gravyframe.Data.Umbraco.Tests
{
    

    [TestFixture]
    public class UmbracoNewsDaoTests : NewsDaoTests
    {
        private INode _newsConfigurationNode;
        private INodeFactoryFacade _nodeFactoryFacade;
        private ISearcher _searcher;

        [SetUp]
        public void SetUp()
        {
            _newsConfigurationNode = Substitute.For<INode>();
            _nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            _searcher = Substitute.For<ISearcher>();
            Sut = new UmbracoNewsDao(_newsConfigurationNode, _nodeFactoryFacade, _searcher);
        }

        [Test]
        public void SomeTest()
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
        public void AndAgain()
        {
            var standFields = new List<IIndexField>
            {
                MockIndexField("id", "Number", true),
            };

            var userFields = new List<IIndexField>
            {
                MockIndexField("categoryId")
            };

            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var directory = new RAMDirectory();
            var simpleDataService = Substitute.For<ISimpleDataService>();

            simpleDataService.GetAllData("News").Returns(new List<SimpleDataSet>
            {
                new SimpleDataSet
                {
                    NodeDefinition = new IndexedNode {NodeId = (2), Type = "News"},
                    RowData = new Dictionary<string, string>
                    {
                        {"categoryId", "TestCategory"}
                    }
                },
                new SimpleDataSet
                {
                    NodeDefinition = new IndexedNode {NodeId = (3), Type = "News"},
                    RowData = new Dictionary<string, string>
                    {
                        {"categoryId", "TestCategory"}
                    }
                }
            });

            var indexCriteria = new IndexCriteria(
                standFields,
                userFields,
                new string[] {},
                new string[] {},
                -1);

            var indexer = new SimpleDataIndexer(indexCriteria, directory, analyzer, simpleDataService, new[] { "News" }, false);

            indexer.IndexAll("News");

            var searcher = new UmbracoExamineSearcher(directory, new KeywordAnalyzer());
            var searchCriteria = searcher.CreateSearchCriteria();
            var query = searchCriteria.Field("categoryId", "TestCategory").Compile();
            //var searchResults = searcher.Search(query);

            //var searchResults = searcher.Search("TestCategory", false);

            var searchResults = searcher.Search(searchCriteria.Id(1).Compile());

            

            Assert.IsTrue(searchResults.TotalItemCount > 0);

        }

        [Test]
        public void another()
        {   
            var standFields = new List<IIndexField>
            {
                MockIndexField("id", "Number", true),
                //MockIndexField("nodeName", true),
                //MockIndexField("updateDate", "DateTime", true),
                //MockIndexField("writerName"),
                //MockIndexField("path"),
                //MockIndexField("nodeTypeAlias"),
                //MockIndexField("parentID"),
                //MockIndexField("sortOrder", "Number", true),

            };

            var userFields = new List<IIndexField>
            {
                MockIndexField("categoryId")
            };

            var dataService = Substitute.For<IDataService>();

            var contentService = Substitute.For<IContentService>();
            contentService.GetAllSystemPropertyNames().Returns(new List<string>());
            contentService.GetAllUserPropertyNames().Returns(new List<string> {"News"});

            var xDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Root",
                    new XElement("News", new XAttribute("id", "2"),
                        new XElement("categoryId", "TestCategory"))
                    )
                );

            contentService.GetLatestContentByXPath("").Returns(xDocument);
            contentService.GetPublishedContentByXPath("").Returns(xDocument);
            contentService.IsProtected(1, "").Returns(false);
            contentService.StripHtml("").Returns("Test");

            dataService.ContentService.Returns(contentService);

            var logService = Substitute.For<ILogService>();
            dataService.LogService.Returns(logService);

            var mediaService = Substitute.For<IMediaService>();
            dataService.MediaService.Returns(mediaService);

            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var directory = new RAMDirectory();

            var indexCriteria = new IndexCriteria(standFields, userFields, new[] { "News" }, new string[] { }, -1);

            var indexer = new UmbracoContentIndexer(indexCriteria, directory, dataService, analyzer, false);


            indexer.RebuildIndex();

            var searcher = new UmbracoExamineSearcher(directory, analyzer);

            var results = _searcher.Search(_searcher.CreateSearchCriteria().Id(2).Compile());

            Assert.IsTrue(results.TotalItemCount > 0);

            //var searchCriteria = searcher.CreateSearchCriteria();
            //var query = searchCriteria.Field("categoryId", "TestCategory").Compile();
            //var result = searcher.Search(query);

            //Assert.IsTrue(result.Any());
        }

        private static IIndexField MockIndexField(string name, bool enableSorting)
        {
            return MockIndexField(name, string.Empty, enableSorting);
        }

        private static IIndexField MockIndexField(string name)
        {
            return MockIndexField(name, string.Empty);
        }

        private static IIndexField MockIndexField(string name, string type, bool enableSorting = false)
        {
            var indexField = Substitute.For<IIndexField>();
            indexField.Name.Returns(name);
            indexField.EnableSorting.Returns(enableSorting);
            indexField.Type.Returns(type);
            return indexField;
        }

        [Test]
        public void SomeOtherTEst()
        {
            var directory = new RAMDirectory();
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);

            var document = new Document();
            document.Add(new Field("Id", "1", Field.Store.YES, Field.Index.NOT_ANALYZED));
            document.Add(new Field("categoryId", "TestCategory", Field.Store.YES, Field.Index.NOT_ANALYZED));
            writer.AddDocument(document);
            
            writer.Optimize();
            writer.Close();


            var searcher = new UmbracoExamineSearcher(directory, new KeywordAnalyzer());

            this.Sut = new UmbracoNewsDao(_newsConfigurationNode, _nodeFactoryFacade, searcher);

            var searchCriteria = searcher.CreateSearchCriteria();
            var query = searchCriteria.Field("categoryId", "TestCategory").Compile();
            var searchResults = searcher.Search(query);

            Assert.IsTrue(searchResults.TotalItemCount > 0);
            var t = searchResults.ToArray();

            var result = Sut.GetNewsByCategoryId("TestCategory");

            Assert.IsTrue(result.Any());
        }

        protected override string GetExampleId()
        {
            return "1";
        }
    }
}
