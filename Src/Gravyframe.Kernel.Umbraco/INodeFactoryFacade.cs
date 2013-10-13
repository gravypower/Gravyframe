using umbraco.interfaces;

namespace Gravyframe.Kernel.Umbraco
{
    public interface INodeFactoryFacade
    {
        INode GetNode(int nodeId);
    }
}
