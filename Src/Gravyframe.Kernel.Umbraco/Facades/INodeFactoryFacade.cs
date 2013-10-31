namespace Gravyframe.Kernel.Umbraco.Facades
{
    using umbraco.interfaces;

    public interface INodeFactoryFacade
    {
        INode GetNode(int nodeId);
    }
}
