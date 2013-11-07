namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class GivenTwoNodeAndTwoSite : Tests
    {
        [SetUp]
        public void SetUp()
        {
            var mockedParentOne = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteNameOne").Mock(10);
            var mockedParentTwo = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteNameTwo").Mock(11);
            var mockedNodeOne = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParentOne).Mock(90);
            var mockedNodeTwo = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParentTwo).Mock(91);

            this.NodeFactoryFacade.GetNode(mockedNodeOne.Id).Returns(mockedNodeOne);
            this.NodeFactoryFacade.GetNode(mockedNodeTwo.Id).Returns(mockedNodeTwo);

            this.MockedContentService.AddNode(mockedNodeOne);
            this.MockedContentService.AddNode(mockedNodeTwo);

            this.DataService.ContentService.Returns(this.MockedContentService);
        }

        [Test]
        public void WhenIndexedDoesIncludeTwoSiteFeild()
        {
            // Act
            this.Sut.IndexAll("test");

            // Assert
            var feilds = this.GetFeildsFromDocumnet();

            Assert.Contains("site", feilds.Keys);
            Assert.Contains("SiteNameOne", feilds["site"]);
            Assert.Contains("SiteNameTwo", feilds["site"]);
        }
    }

}
