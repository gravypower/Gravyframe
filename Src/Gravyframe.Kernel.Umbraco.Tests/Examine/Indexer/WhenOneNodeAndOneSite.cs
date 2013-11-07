namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class WhenOneNodeAndOneSite : Tests
    {
        [SetUp]
        public void WhenOneNodeAndOneSiteSetUp()
        {
            var mockedParent = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteName").Mock(10);
            var mockedNode = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);

            this.NodeFactoryFacade.GetNode(mockedNode.Id).Returns(mockedNode);

            this.MockedContentService.AddNode(mockedNode);
            this.DataService.ContentService.Returns(this.MockedContentService);
        }

        [Test]
        public void DoesIncludeSiteFeild()
        {
            // Act
            this.Sut.IndexAll("test");

            // Assert
            var feilds = this.GetFeildsFromDocumnet();

            Assert.Contains("site", feilds.Keys);
            Assert.Contains("SiteName", feilds["site"]);
        }
    }
}
