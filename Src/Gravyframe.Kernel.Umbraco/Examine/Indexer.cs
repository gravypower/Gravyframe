using UmbracoExamine;
using Examine;
using Gravyframe.Kernel.Umbraco.Extension;

namespace Gravyframe.Kernel.Umbraco.Examine
{
    public class Indexer : BaseUmbracoIndexer
    {
        protected override System.Collections.Generic.IEnumerable<string> SupportedTypes
        {
            get
            {
                return new[] { IndexTypes.Content };
            }
        }

        protected override void OnGatheringNodeData(IndexingNodeDataEventArgs e)
        {
            var currentNode = new umbraco.NodeFactory.Node(e.NodeId);
            var siteNode = currentNode.FindNodeUpTree("Site");
            if (siteNode.Id != -1)
            {
                e.Fields.Add("site", siteNode.UrlName);
            }
        }
    }
}
