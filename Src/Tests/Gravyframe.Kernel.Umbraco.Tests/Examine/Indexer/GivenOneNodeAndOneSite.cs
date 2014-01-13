using NSubstitute;
using NUnit.Framework;
using umbraco.interfaces;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    using TestHelpers;

    [TestFixture]
    public class GivenOneNodeAndOneSite : Tests
    {
        public INode MockedNode;

        [SetUp]
        public void SetUp()
        {
            var mockedParent = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteName").Mock(10);
            MockedNode = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);

            NodeFactoryFacade.GetNode(MockedNode.Id).Returns(MockedNode);

            MockedContentService.AddNode(MockedNode);
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

        [TestFixture]
        public class AndCategories : GivenOneNodeAndOneSite
        {
            /// <summary>
            /// And the categories set up.
            /// </summary>
            [SetUp]
            public void AndCategories_SetUp()
            {
                MockedNode = new MockNode(MockedNode)
                    .AddProperty("categories", "1063,1064")
                    .Mock(90);

                NodeFactoryFacade.GetNode(MockedNode.Id).Returns(MockedNode);

                MockedContentService.AddNode(MockedNode);
                DataService.ContentService.Returns(MockedContentService);
            }

            [Test]
            public void CategoriesAddedToDocument()
            {
                // Act
                Sut.IndexAll("test");

                // Assert
                var fields = GetFieldsFromDocument();

                Assert.Contains("categories", fields.Keys);
                Assert.Contains("1063|1064", fields["categories"]);
            }
        }
    }
}