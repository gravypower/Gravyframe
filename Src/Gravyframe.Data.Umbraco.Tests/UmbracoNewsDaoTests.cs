using System.Collections.Generic;
using Examine;
using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco;
using Gravyframe.Kernel.Umbraco.Tests;
using Lucene.Net.Documents;
using NSubstitute;
using NUnit.Framework;
using UmbracoExamine;
using umbraco.interfaces;

namespace Gravyframe.Data.Umbraco.Tests
{
    using System.Linq;

    using Examine.Providers;

    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Index;
    using Lucene.Net.Store;
    using Lucene.Net.Util;

    [TestFixture]
    public class UmbracoNewsDaoTests : NewsDaoTests
    {
        private INode _newsConfigrationNode;
        private INodeFactoryFacade _nodeFactoryFacade;
        private ISearcher _searcher;

        [SetUp]
        public void SetUp()
        {
            _newsConfigrationNode = Substitute.For<INode>();
            _nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            _searcher = Substitute.For<ISearcher>();
            Sut = new UmbracoNewsDao(_newsConfigrationNode, _nodeFactoryFacade, _searcher);
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

            this.Sut = new UmbracoNewsDao(_newsConfigrationNode, _nodeFactoryFacade, searcher);

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
