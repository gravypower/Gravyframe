using System.Collections.Generic;
using NSubstitute;
using umbraco.interfaces;

namespace Gravyframe.Kernel.Umbraco.Tests
{
    public class MockNodeFactory
    {
        public static INode BuildNode(IDictionary<string, object> properties)
        {
            var node = Substitute.For<INode>();
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
