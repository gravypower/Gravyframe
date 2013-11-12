using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    [TestFixture]
    public class GivenOneNodeAndOneSite : Tests
    {
        [SetUp]
        public void SetUp()
        {
            var mockedParent = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteName").Mock(10);
            var mockedNode = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);

            NodeFactoryFacade.GetNode(mockedNode.Id).Returns(mockedNode);

            MockedContentService.AddNode(mockedNode);
            DataService.ContentService.Returns(MockedContentService);
        }

        [Test]
        public void WhenIndexedDoesIncludeSiteField()
        {
            // Act
            Sut.IndexAll("test");

            // Assert
            var fields = GetFieldsFromDocument();

            Assert.Contains("site", fields.Keys);
            Assert.Contains("SiteName", fields["site"]);
        }
    }
}