using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using NUnit.Framework;
using umbraco.interfaces;
using UmbracoExamine.DataServices;

namespace Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine.MockContentService
{
    public class MockedContentService : IContentService
    {
        private readonly List<INode> _nodes;

        public MockedContentService()
        {
            _nodes = new List<INode>();
        }

        public MockedContentService AddNode(INode node)
        {
            Assert.IsNotNullOrEmpty(node.NodeTypeAlias, "Node Type Alias can not be null or empty when mocking IContentService");

            _nodes.Add(node);

            return this;
        }

        public IEnumerable<string> GetAllSystemPropertyNames()
        {
            return new string[]{};
        }

        public IEnumerable<string> GetAllUserPropertyNames()
        {
            return new string[] { };
        }

        public XDocument GetLatestContentByXPath(string xpath)
        {
            return  GetPublishedContentByXPath(xpath);
        }

        public XDocument GetPublishedContentByXPath(string xpath)
        {

            var xdoc = XDocument.Parse("<content></content>");
            foreach (var node in this._nodes)
            {
                var n = new XElement(node.NodeTypeAlias, new XAttribute("id", node.Id));

                foreach (var property in node.PropertiesAsList)
                {
                    n.Add(new XElement(property.Alias, new XCData(property.Value)));
                }

                xdoc.Root.Add(n);
            }

            return xdoc;
        }

        public bool IsProtected(int nodeId, string path)
        {
            return false;
        }

        public string StripHtml(string value)
        {
            const string pattern = @"<(.|\n)*?>";
            return Regex.Replace(value, pattern, string.Empty);
        }
    }
}
