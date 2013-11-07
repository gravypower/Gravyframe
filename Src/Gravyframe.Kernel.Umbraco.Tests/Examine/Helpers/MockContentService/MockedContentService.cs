using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using UmbracoExamine.DataServices;
using umbraco.interfaces;
namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockContentService
{
    using NUnit.Framework;

    public class MockedContentService : IContentService
    {
        private readonly List<INode> nodes;

        public MockedContentService()
        {
            nodes = new List<INode>();
        }

        public MockedContentService AddNode(INode node)
        {
            Assert.IsNotNullOrEmpty(node.NodeTypeAlias, "Node Type Alias can not be null or empty when mocking IContentService");

            nodes.Add(node);

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
            foreach (var node in this.nodes)
            {
                xdoc.Root.Add(new XElement(node.NodeTypeAlias, new XAttribute("id", node.Id)));
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
