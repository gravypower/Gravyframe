using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Examine.LuceneEngine;
using Lucene.Net.Documents;
using UmbracoExamine;
using Examine;
using Gravyframe.Kernel.Umbraco.Extension;
using Gravyframe.Kernel.Umbraco.Facades;
using Lucene.Net.Analysis;
using UmbracoExamine.DataServices;
using Directory = Lucene.Net.Store.Directory;

namespace Gravyframe.Kernel.Umbraco.Examine
{
    public class Indexer : BaseUmbracoIndexer
    {
        private readonly INodeFactoryFacade _nodeFactoryFacade;

        public Indexer()
        {
            _nodeFactoryFacade = new NodeFactoryFacade();
        }

        public Indexer(IIndexCriteria indexerData, DirectoryInfo indexPath, IDataService dataService, Analyzer analyzer,
            bool async)
            : base(indexerData, indexPath, dataService, analyzer, async)
        {
            _nodeFactoryFacade = new NodeFactoryFacade();
        }

        public Indexer(
            IIndexCriteria indexerData,
            Directory luceneDirectory,
            IDataService dataService,
            Analyzer analyzer,
            bool async,
            INodeFactoryFacade nodeFactoryFacade)
            : base(indexerData, luceneDirectory, dataService, analyzer, async)
        {
            _nodeFactoryFacade = nodeFactoryFacade;
        }

        protected override IEnumerable<string> SupportedTypes
        {
            get
            {
                return new[] { IndexTypes.Content };
            }
        }

        protected override void OnGatheringNodeData(IndexingNodeDataEventArgs e)
        {
            var currentNode = _nodeFactoryFacade.GetNode(e.NodeId);
            var siteNode = currentNode.FindNodeUpTree("Site");
            if (siteNode != null && siteNode.Id != -1)
            {
                e.Fields.Add("site", siteNode.UrlName);
            }
        }

        protected override void OnDocumentWriting(DocumentWritingEventArgs docArgs)
        {
            var currentNode = _nodeFactoryFacade.GetNode(docArgs.NodeId);

            var categories = currentNode.GetProperty("categories").Value;
            if (!string.IsNullOrEmpty(categories))
            {
                var categoryNodeIdsXml = XElement.Parse(categories);
                var categoryNodeIds = categoryNodeIdsXml.Descendants("nodeId");
                docArgs.Document.Add(new Field("categories", string.Join("|", categoryNodeIds.Select(x=>x.Value)) , Field.Store.YES, Field.Index.ANALYZED));
            }

            base.OnDocumentWriting(docArgs);
        }
    }
}
