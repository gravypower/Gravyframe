using Gravyframe.Configuration;
using Gravyframe.Configuration.Umbraco;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Kernel.Umbraco.Tests;
using Gravyframe.Kernel.Umbraco.Tests.Examine;
using Gravyframe.Models.Umbraco;
using Gravyframe.ServiceStack.Tests;
using NSubstitute;
using NUnit.Framework;
using ServiceStack.ServiceClient.Web;
using ServiceStack.WebHost.Endpoints;

namespace Gravyframe.ServiceStack.Umbraco.Tests
{
    [TestFixture]
    public class UmbracoNewsAppHostTests : NewsAppHostTests<UmbracoNews>
    {
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

        public class t : AppHostHttpListenerBase
        {
            private readonly MockedIndex _mockedIndex;
            private readonly INodeFactoryFacade _nodeFactoryFacade;
            public t(MockedIndex mockedIndex, INodeFactoryFacade nodeFactoryFacade)
                : base("Gravyframe News Web Services", typeof(UmbracoNewsService).Assembly)
            {
                _mockedIndex = mockedIndex;
                _nodeFactoryFacade = nodeFactoryFacade;
            }


            public override void Configure(Funq.Container container)
            {
                var t1 = new TestUmbracoNewsAppHost(_mockedIndex, _nodeFactoryFacade);
                t1.Configure(container);

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

            var mockDataSet = new MockSimpleDataSet("News");
            mockDataSet.AddData(1, UmbracoNewsDao.CategoriesAlias, "TestCategoryId");

            mockedIndex.SimpleDataService.GetAllData("News").Returns(mockDataSet);
            var nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();

            var mockNode = new MockNode()
               .AddProperty(UmbracoNewsDao.BodyAlias, "BodyText")
               .Mock();

            nodeFactoryFacade.GetNode(1).Returns(mockNode);

            mockedIndex.Indexer.RebuildIndex();

            Sut = new t(mockedIndex, nodeFactoryFacade);
            Sut.Container.Register(mockedIndex.Searcher);
            Sut.Init();
            

            //Sut.Start(ListeningOn);

            RestClient = new JsonServiceClient(ListeningOn);
        }


        public override string GetTestNewsId()
        {
            return "1";
        }

        public override string GetTestCategoryId()
        {
            return "TestCategoryId";
        }
    }
}
