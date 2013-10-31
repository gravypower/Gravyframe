namespace Gravyframe.Kernel.Umbraco.Facades
{
    using umbraco.interfaces;
    using umbraco.NodeFactory;

    public class NodeFactoryFacade : INodeFactoryFacade
    {
        public INode GetNode(int nodeId)
        {
            return new Node(nodeId);
        }
    }
}
