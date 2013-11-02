using System.Collections.Generic;
using NSubstitute;
using umbraco.interfaces;

namespace Gravyframe.Kernel.Umbraco.Tests
{
    public class MockNode
    {
        private readonly IDictionary<string, object> properties;

        public MockNode()
        {
            this.properties = new Dictionary<string, object>();
        }

        public MockNode AddProperty(string alias, string value)
        {
            properties.Add(alias, value);
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

            return node;
        }
    }
}
