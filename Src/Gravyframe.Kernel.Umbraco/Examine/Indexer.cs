using System.Collections.Generic;
using System.Security;
using Lucene.Net.Store;
using UmbracoExamine;
using Examine;
using Gravyframe.Kernel.Umbraco.Extension;
using Gravyframe.Kernel.Umbraco.Facades;
using Lucene.Net.Analysis;
using UmbracoExamine.DataServices;

namespace Gravyframe.Kernel.Umbraco.Examine
{
    public class Indexer : BaseUmbracoIndexer
    {
        private readonly INodeFactoryFacade _nodeFactoryFacade;

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
    }
}
