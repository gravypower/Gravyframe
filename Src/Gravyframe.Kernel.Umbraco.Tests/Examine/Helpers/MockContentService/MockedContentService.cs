using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using UmbracoExamine.DataServices;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockContentService
{
    public class MockedContentService : IContentService
    {
        private readonly XDocument _xDoc;

        public MockedContentService()
        {
            _xDoc = new XDocument();
            _xDoc.Add(
                new XElement("test", new XAttribute("id", 90))
                );
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
            var xdoc = XDocument.Parse("<content></content>");
            if (xdoc.Root != null)
            {
                xdoc.Root.Add(this._xDoc.FirstNode);
            }

            return xdoc;
        }

        public XDocument GetPublishedContentByXPath(string xpath)
        {
            var xdoc = XDocument.Parse("<content></content>");
            if (xdoc.Root != null)
            {
                xdoc.Root.Add(this._xDoc.FirstNode);
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
