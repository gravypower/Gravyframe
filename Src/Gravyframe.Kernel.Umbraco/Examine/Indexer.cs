using UmbracoExamine;
using Examine;
using Gravyframe.Kernel.Umbraco.Extension;
using Gravyframe.Kernel.Umbraco.Facades;
using System.IO;
using Lucene.Net.Analysis;
using UmbracoExamine.DataServices;
using Directory = Lucene.Net.Store.Directory;

namespace Gravyframe.Kernel.Umbraco.Examine
{
    public class Indexer : BaseUmbracoIndexer
    {
        private readonly INodeFactoryFacade nodeFactoryFacade;

        public Indexer(
            IIndexCriteria indexerData,
            DirectoryInfo indexPath,
            IDataService dataService,
            Analyzer analyzer,
            bool async,
            INodeFactoryFacade nodeFactoryFacade)
            : base(indexerData, indexPath, dataService, analyzer, async)
        {
            this.nodeFactoryFacade = nodeFactoryFacade;
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
            this.nodeFactoryFacade = nodeFactoryFacade;
        }

        protected override System.Collections.Generic.IEnumerable<string> SupportedTypes
        {
            get
            {
                return new[] { IndexTypes.Content };
            }
        }

        protected override void OnGatheringNodeData(IndexingNodeDataEventArgs e)
        {
            var currentNode = this.nodeFactoryFacade.GetNode(e.NodeId);
            var siteNode = currentNode.FindNodeUpTree("Site");
            if (siteNode.Id != -1)
            {
                e.Fields.Add("site", siteNode.UrlName);
            }
        }
    }
}
