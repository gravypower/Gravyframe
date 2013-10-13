using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Gravyframe.Kernel.Umbraco
{
    public class NodeFactoryFacade : INodeFactoryFacade
    {
        public INode GetNode(int nodeId)
        {
            return new Node(nodeId);
        }
    }
}
