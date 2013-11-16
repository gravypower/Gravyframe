namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    using TestHelpers;

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

            NodeFactoryFacade.GetNode(mockedNodeOne.Id).Returns(mockedNodeOne);
            NodeFactoryFacade.GetNode(mockedNodeTwo.Id).Returns(mockedNodeTwo);

            MockedContentService.AddNode(mockedNodeOne);
            MockedContentService.AddNode(mockedNodeTwo);

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
