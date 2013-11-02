using umbraco.interfaces;
using Gravyframe.Kernel.Umbraco.Facades;
namespace Gravyframe.Configuration.Umbraco
{
    public class UmbracoNewsConfiguration : INewsConfiguration
    {
        private readonly INodeFactoryFacade _nodeFactoryFacade;
        private readonly int _newsConfigurationNodeId;
        public const string DefaultListSizePropertyAlias = "defaultListSize";

        private INode _newsConfigurationNode;
        public INode NewsConfigurationNode
        {
            get
            {
                if (_newsConfigurationNode == null)
                {
                    _newsConfigurationNode = _nodeFactoryFacade.GetNode(_newsConfigurationNodeId);
                }
                return _newsConfigurationNode;
            }
        }

        public string NewsIdError
        {
            get
            {
                return string.Empty;
            }
        }

        public string NewsCategoryIdError
        {
            get
            {
                return string.Empty;
            }
        }

        private int _defaultListSize;
        public int DefaultListSize
        {
            get
            {
                if (!int.TryParse(NewsConfigurationNode.GetProperty(DefaultListSizePropertyAlias).Value, out _defaultListSize))
                {
                    var newsConstants = new NewsConfiguration();
                    _defaultListSize = newsConstants.DefaultListSize;
                }

                return _defaultListSize;
            }
        }

        public UmbracoNewsConfiguration(INodeFactoryFacade nodeFactoryFacade, int newsConfigurationNodeId)
        {
            _nodeFactoryFacade = nodeFactoryFacade;
            _newsConfigurationNodeId = newsConfigurationNodeId;
        }
    }
}
