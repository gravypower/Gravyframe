using umbraco.interfaces;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Kernel.Umbraco.Extension;

namespace Gravyframe.Configuration.Umbraco
{
    public class UmbracoNewsConfiguration : NewsConfiguration
    {
        private readonly INodeFactoryFacade _nodeFactoryFacade;
        private readonly int _configurationNodeId;
        public const string DefaultListSizePropertyAlias = "defaultListSize";

        private INode _configurationNode;
        public INode ConfigurationNode
        {
            get
            {
                if (_configurationNode == null)
                {
                    _configurationNode = _nodeFactoryFacade.GetNode(_configurationNodeId);
                }

                return _configurationNode;
            }
        }

        private int? _defaultListSize;
        public override int DefaultListSize
        {
            get
            {
                if (!_defaultListSize.HasValue)
                {
                    _defaultListSize = ConfigurationNode.GetProperty(DefaultListSizePropertyAlias, base.DefaultListSize, int.TryParse);
                }

                return _defaultListSize.Value;
            }
        }

        public UmbracoNewsConfiguration(INodeFactoryFacade nodeFactoryFacade, int configurationNodeId)
        {
            _nodeFactoryFacade = nodeFactoryFacade;
            _configurationNodeId = configurationNodeId;
        }
    }
}
