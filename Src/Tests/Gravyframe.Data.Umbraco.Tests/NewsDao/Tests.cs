namespace Gravyframe.Data.Umbraco.Tests.NewsDao
{
    using System.Linq;

    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    using NUnit.Framework;

    using umbraco.interfaces;

    [TestFixture]
    public class Tests : Tests<UmbracoNews>
    {
        protected TestContext TestContext;

        [SetUp]
        public void SetUp()
        {
            this.TestContext = new TestContext();
            this.Context = this.TestContext;
        }
        
        [Test]
        public void GetNewsByCategoryIdFromUmbracoExamineIndex()
        {
            // Assign
            this.TestContext.MockNewsItemsInIndex(1);

            // Act
            var result = this.TestContext.Sut.GetNewsByCategoryId(TestContext.TestCategoryId);

            // Assert
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetNewsByCategoryListIsDefaultSize1()
        {
            // Assign
            var mockNode = new MockNode().Mock(2);
            this.TestContext.NodeFactoryFacade.GetNode(TestContext.NewsConfigurationNodeId).Returns(mockNode);
            var newsConfiguration = new TestContext.TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, this.TestContext.Sut.NewsConfiguration.DefaultListSize);
        }

        [Test]
        public void GetNewsFromUmbraco()
        {
            // Assign
            var mockNode = new MockNode()
                .AddProperty(News.NewsDao.BodyAlias, "Test")
                .Mock();

            this.TestContext.NodeFactoryFacade.GetNode(1).Returns(mockNode);

            // Act
            var result = this.TestContext.Sut.GetNews("1");

            // Assert
            Assert.AreEqual("Test", result.Body);
        }

        [Test]
        public void GetNullNewsFromUmbraco()
        {
            this.TestContext.NodeFactoryFacade.GetNode(1).Returns(default(INode));

            // Act
            var result = this.TestContext.Sut.GetNews("1");

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void WhenNewsConfigurationNodeIsNullDefaultListSize()
        {
            // Assign
            this.TestContext.NodeFactoryFacade.GetNode(TestContext.NewsConfigurationNodeId).Returns(default(INode));
            var newsConfiguration = new TestContext.TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, this.TestContext.Sut.NewsConfiguration.DefaultListSize);
        }
    }
}