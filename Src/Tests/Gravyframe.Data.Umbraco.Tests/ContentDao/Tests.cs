namespace Gravyframe.Data.Umbraco.Tests.ContentDao
{
    using Gravyframe.Data.Tests.ContentDao;
    using Gravyframe.Data.Umbraco.Content;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    using NUnit.Framework;

    using umbraco.interfaces;

    [TestFixture]
    public class Tests: Tests<Content>
    {
        private const int ExampleID = 2;
        protected TestContext TestContext;

        [SetUp]
        public void SetUp()
        {
            this.TestContext = new TestContext();
            this.Context = this.TestContext;

            this.TestContext.MockNewsItemsInIndex();
            var mockNode = new MockNode().Mock(ExampleID);

            TestContext.NodeFactoryFacade.GetNode(ExampleID).Returns(mockNode);
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

            this.TestContext.NodeFactoryFacade.GetNode(ExampleID).Returns(mockNode);

            // Act
            var result = this.Context.Sut.GetContent(this.TestContext.ExampleId);

            // Assert
            Assert.That(result.Id, Is.EqualTo(ExampleID));
            Assert.That(result.Title, Is.EqualTo(title));
            Assert.That(result.Body, Is.EqualTo(body));
        }

        [Test]
        public void GetNullNewsFromUmbraco()
        {
            this.TestContext.NodeFactoryFacade.GetNode(1).Returns(default(INode));

            // Act
            var result = this.Context.Sut.GetContent("1");

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
