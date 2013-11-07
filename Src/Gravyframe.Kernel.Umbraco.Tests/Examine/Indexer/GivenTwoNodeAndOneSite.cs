namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class GivenTwoNodeAndOneSite : Tests
    {
        [SetUp]
        public void SetUp()
        {
            var mockedParent = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteName").Mock(10);
            var mockedNodeOne = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);
            var mockedNodeTwo = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(91);

            this.NodeFactoryFacade.GetNode(mockedNodeOne.Id).Returns(mockedNodeOne);
            this.NodeFactoryFacade.GetNode(mockedNodeTwo.Id).Returns(mockedNodeTwo);

            this.MockedContentService.AddNode(mockedNodeOne);
            this.MockedContentService.AddNode(mockedNodeTwo);

            this.DataService.ContentService.Returns(this.MockedContentService);
        }

        [Test]
        public void WhenIndexedDoesIncludeSiteFeild()
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
