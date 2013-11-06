using System.Collections.Generic;
using NSubstitute;
using umbraco.interfaces;

namespace Gravyframe.Kernel.Umbraco.Tests
{
    public class MockNode
    {
        private readonly IDictionary<string, object> properties;

        private INode parent;

        protected string NodeTypeAlias;
        protected string UrlName;

        public MockNode()
        {
            this.properties = new Dictionary<string, object>();
        }

        public MockNode AddNodeTypeAlias(string nodeTypeAlias)
        {
            NodeTypeAlias = nodeTypeAlias;
            return this;
        }

        public MockNode AddUrlName(string urlName)
        {
            UrlName = urlName;
            return this;
        }

        public MockNode AddProperty(string alias, string value)
        {
            properties.Add(alias, value);
            return this;
        }

        public MockNode AddParent(INode parentNode)
        {
            parent = parentNode;
            return this;
        }

        public INode Mock(int nodeId)
        {
            var node = Substitute.For<INode>();
            node.Id.ReturnsForAnyArgs(nodeId);
            foreach (var pair in properties)
            {
                var property = Substitute.For<IProperty>();
                property.Alias.Returns(pair.Key);
                property.Value.Returns(pair.Value);
                node.GetProperty(pair.Key).Returns(property);
            }

            if(!string.IsNullOrEmpty(this.NodeTypeAlias))
            {
                node.NodeTypeAlias.Returns(this.NodeTypeAlias);
            }

            if (!string.IsNullOrEmpty(UrlName))
            {
                node.UrlName.Returns(UrlName);
            }

            if (parent != null)
            {
                node.Parent.Returns(parent);
            }

            

            return node;
        }
    }
}
