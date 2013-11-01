using Gravyframe.Configuration;
using Gravyframe.Configuration.Umbraco;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Kernel.Umbraco.Tests;
using Gravyframe.Kernel.Umbraco.Tests.Examine;
using Gravyframe.Models.Umbraco;
using Gravyframe.Service.News;
using NSubstitute;
using NUnit.Framework;
using ServiceStack.Service;
using ServiceStack.ServiceClient.Web;

namespace Gravyframe.ServiceStack.Umbraco.Tests
{
    [TestFixture]
    public class NewsAppHostTests
    {

        private TestUmbracoNewsAppHost _sut;
        private const string BaseUrl = "http://localhost:8024";
        private const string ListeningOn = BaseUrl + "/";
        private IRestClient _jsonServiceClient;

        private class TestUmbracoNewsAppHost : UmbracoNewsAppHost
        {
            private readonly MockedIndex _mockedIndex;
            private readonly INodeFactoryFacade _nodeFactoryFacade;

            public TestUmbracoNewsAppHost(MockedIndex mockedIndex, INodeFactoryFacade nodeFactoryFacade)
            {
                _mockedIndex = mockedIndex;
                _nodeFactoryFacade = nodeFactoryFacade;
            }

            protected override void RegisterExternalDependencies()
            {
                Register(_mockedIndex.Searcher);
                Register(_nodeFactoryFacade);
                Register<INewsConfiguration>(new UmbracoNewsConfiguration(Resolve<INodeFactoryFacade>(), 1));
            }
        }

        [SetUp]
        public void SetUp()
        {
            var mockedIndex = MockIndexFactory.GetMock(
               new MockIndexFieldList().AddIndexField("id", "Number", true),
               new MockIndexFieldList().AddIndexField(UmbracoNewsDao.CategoriesAlias),
               new[] { "News" },
               new string[] { },
               new string[] { });

            var nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();


            var mockNode = new MockNode()
               .AddProperty(UmbracoNewsDao.BodyAlias, "BodyText")
               .Mock();

            nodeFactoryFacade.GetNode(1).Returns(mockNode);

            _sut = new TestUmbracoNewsAppHost(mockedIndex, nodeFactoryFacade);
            _sut.Container.Register(mockedIndex.Searcher);
            _sut.Init();
            _sut.Start(ListeningOn);

            _jsonServiceClient = new JsonServiceClient(ListeningOn);
        }

        [TearDown]
        public void TearDown()
        {
            _sut.Dispose();
        }

        [Test]
        public void Test()
        {
            // Act
            var result = _jsonServiceClient.Get<NewsResponse<UmbracoNews>>("/NewsService/");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
