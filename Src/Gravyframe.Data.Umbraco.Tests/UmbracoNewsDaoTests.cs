using System.Collections.Generic;
using Examine;
using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco;
using Gravyframe.Kernel.Umbraco.Tests;
using NSubstitute;
using NUnit.Framework;
using umbraco.interfaces;

namespace Gravyframe.Data.Umbraco.Tests
{
    using Lucene.Net.Analysis;
    using Lucene.Net.Index;
    using Lucene.Net.Search;
    using Lucene.Net.Store;

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
            var document = new Lucene.Net.Documents.Document();
            var directory = new RAMDirectory();
            var analyzer = new SimpleAnalyzer();
            var writer = new IndexWriter(directory, analyzer, true);

            writer.AddDocument(document);

            writer.Close();


            var reader = IndexReader.Open(directory, true);
            var searcher = new IndexSearcher(reader);

            //searcher.Search()

            reader.Close();
            searcher.Close();


        }

        protected override string GetExampleId()
        {
            return "1";
        }
    }
}
