﻿namespace Gravyframe.Kernel.Umbraco.Tests.TestHelpers
{
    using System.Collections.Generic;

    using NSubstitute;

    using umbraco.interfaces;

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

        public MockNode(INode mockedNode)
        {
            this.properties = new Dictionary<string, object>();

            foreach (var property in mockedNode.PropertiesAsList)
            {
                properties.Add(property.Alias, property.Value);
            }

            this.NodeTypeAlias = mockedNode.NodeTypeAlias;
            this.UrlName = mockedNode.UrlName;
            this.parent = mockedNode.Parent;
        }

        public MockNode AddNodeTypeAlias(string nodeTypeAlias)
        {
            this.NodeTypeAlias = nodeTypeAlias;
            return this;
        }

        public MockNode AddUrlName(string urlName)
        {
            this.UrlName = urlName;
            return this;
        }

        public MockNode AddProperty(string alias, string value)
        {
            this.properties.Add(alias, value);
            return this;
        }

        public MockNode AddParent(INode parentNode)
        {
            this.parent = parentNode;
            return this;
        }

        public INode Mock(int nodeId = 1)
        {
            var node = Substitute.For<INode>();
            node.Id.ReturnsForAnyArgs(nodeId);
            var propertiesAsList = new List<IProperty>();
            foreach (var pair in this.properties)
            {
                var property = Substitute.For<IProperty>();
                property.Alias.Returns(pair.Key);
                property.Value.Returns(pair.Value);
                node.GetProperty(pair.Key).Returns(property);
                propertiesAsList.Add(property);
            }

            node.PropertiesAsList.Returns(propertiesAsList);

            if(!string.IsNullOrEmpty(this.NodeTypeAlias))
            {
                node.NodeTypeAlias.Returns(this.NodeTypeAlias);
            }

            if (!string.IsNullOrEmpty(this.UrlName))
            {
                node.UrlName.Returns(this.UrlName);
            }

            if (this.parent != null)
            {
                node.Parent.Returns(this.parent);
            }

            

            return node;
        }
    }
}
