namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    using TestHelpers;

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
            var mockedNodeOne = new MockNode()
                .AddNodeTypeAlias("test")
                .AddParent(mockedParentOne)
                .Mock(90);

            var mockedNodeTwo = new MockNode()
                .AddNodeTypeAlias("test")
                .AddParent(mockedParentTwo)
                .Mock(91);

            NodeFactoryFacade.GetNode(mockedNodeOne.Id).Returns(mockedNodeOne);
            NodeFactoryFacade.GetNode(mockedNodeTwo.Id).Returns(mockedNodeTwo);

            MockedContentService.AddNode(mockedNodeOne);
            MockedContentService.AddNode(mockedNodeTwo);

            DataService.ContentService.Returns(MockedContentService);
        }

        [Test]
        public void WhenIndexedDoesIncludeTwoSiteField()
        {
            // Act
            Sut.IndexAll("test");

            // Assert
            var fields = GetFieldsFromDocument();

            Assert.Contains("site", fields.Keys);
            Assert.Contains("SiteNameOne", fields["site"]);
            Assert.Contains("SiteNameTwo", fields["site"]);
        }
    }

}
