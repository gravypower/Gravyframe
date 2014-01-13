namespace Gravyframe.Data.Umbraco.Tests.ContentDao
{
    using Gravyframe.Configuration.Umbraco;
    using Gravyframe.Data.Tests.ContentDao;
    using Gravyframe.Data.Umbraco.Content;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    using NUnit.Framework;

    using umbraco.interfaces;

    [TestFixture]
    public class Tests: Tests<UmbracoContent>
    {
        public INodeFactoryFacade NodeFactoryFacade;

        private const int ExampleID = 2;

        [SetUp]
        public void SetUp()
        {
            this.NodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            Sut = new ContentDao(NodeFactoryFacade);
            var mockNode = new MockNode().Mock(ExampleID);

            NodeFactoryFacade.GetNode(ExampleID).Returns(mockNode);
        }

        [Test]
        public void IdPopulated()
        {
            // Assign
            var title = "title";
            var body = "body";
            var mockNode = new MockNode()
            .AddProperty(ContentDao.TitleAlias, title)
            .AddProperty(ContentDao.BodyAlias, body)
                .Mock(ExampleID);

            NodeFactoryFacade.GetNode(ExampleID).Returns(mockNode);

            // Act
            var result = Sut.GetContent(this.GetExampleId());

            // Assert
            Assert.That(result.Id, Is.EqualTo(ExampleID));
            Assert.That(result.Title, Is.EqualTo(title));
            Assert.That(result.Body, Is.EqualTo(body));
        }

        [Test]
        public void GetNullNewsFromUmbraco()
        {
            this.NodeFactoryFacade.GetNode(1).Returns(default(INode));

            // Act
            var result = Sut.GetContent("1");

            // Assert
            Assert.AreEqual(null, result);
        }

        protected override string GetExampleCategoryId()
        {
            return "ExampleCategoryId";
        }

        protected override string GetExampleId()
        {
            return ExampleID.ToString();
        }
    }
}
