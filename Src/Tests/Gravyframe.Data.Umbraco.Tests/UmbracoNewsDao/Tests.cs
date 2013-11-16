namespace Gravyframe.Data.Umbraco.Tests.UmbracoNewsDao
{
    using System.Linq;

    using NSubstitute;

    using NUnit.Framework;
    using umbraco.interfaces;

    using Data.Tests.NewsDao;

    using Kernel.Umbraco.Tests.TestHelpers;

    using Models.Umbraco;

    [TestFixture]
    public class Tests : Tests<UmbracoNews>
    {
        protected TestContext TestContext;

        [SetUp]
        public void SetUp()
        {
            TestContext = new TestContext();
            this.Context = TestContext;
        }
        
        [Test]
        public void GetNewsByCategoryIdFromUmbracoExamineIndex()
        {
            // Assign
            TestContext.MockNewsItemsInIndex(1);

            // Act
            var result = TestContext.Sut.GetNewsByCategoryId(TestContext.TestCategoryId);

            // Assert
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetNewsByCategoryListIsDefaultSize1()
        {
            // Assign
            var mockNode = new MockNode().Mock(2);
            TestContext.NodeFactoryFacade.GetNode(TestContext.NewsConfigurationNodeId).Returns(mockNode);
            var newsConfiguration = new TestContext.TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, TestContext.Sut.NewsConfiguration.DefaultListSize);
        }

        [Test]
        public void GetNewsFromUmbraco()
        {
            // Assign
            var mockNode = new MockNode()
                .AddProperty(News.UmbracoNewsDao.BodyAlias, "Test")
                .Mock();

            TestContext.NodeFactoryFacade.GetNode(1).Returns(mockNode);

            // Act
            var result = TestContext.Sut.GetNews("1");

            // Assert
            Assert.AreEqual("Test", result.Body);
        }

        [Test]
        public void GetNullNewsFromUmbraco()
        {
            TestContext.NodeFactoryFacade.GetNode(1).Returns(default(INode));

            // Act
            var result = TestContext.Sut.GetNews("1");

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void WhenNewsConfigurationNodeIsNullDefaultListSize()
        {
            // Assign
            TestContext.NodeFactoryFacade.GetNode(TestContext.NewsConfigurationNodeId).Returns(default(INode));
            var newsConfiguration = new TestContext.TestNewsConfiguration();

            //Assert
            Assert.AreEqual(newsConfiguration.DefaultListSize, TestContext.Sut.NewsConfiguration.DefaultListSize);
        }
    }
}