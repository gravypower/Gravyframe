using Gravyframe.Kernel.Umbraco;
using umbraco.interfaces;

namespace Gravyframe.Constants.Umbraco
{
    /// <summary>
    /// 
    /// </summary>
    public class UmbracoNewsConstants : INewsConstants
    {
        private readonly INodeFactoryFacade _nodeFactoryFacade;
        private readonly int _newsConfigurationNodeId;
        public const string DefaultListSizePropertyAlias = "DefaultListSize";
        public string NewsIdError { get; private set; }
        public string NewsCategoryIdError { get; private set; }

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

        private int _defaultListSize;
        public int DefaultListSize
        {
            get
            {
                if (!int.TryParse(NewsConfigurationNode.GetProperty(DefaultListSizePropertyAlias).Value, out _defaultListSize))
                {
                    var newsConstants = new NewsConstants();
                    _defaultListSize = newsConstants.DefaultListSize;
                }

                return _defaultListSize;
            }
        }

        public UmbracoNewsConstants(INodeFactoryFacade nodeFactoryFacade, int newsConfigurationNodeId)
        {
            _nodeFactoryFacade = nodeFactoryFacade;
            _newsConfigurationNodeId = newsConfigurationNodeId;
        }
    }
}
