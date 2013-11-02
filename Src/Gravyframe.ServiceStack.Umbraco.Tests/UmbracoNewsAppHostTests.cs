using Examine;
using Funq;
using Gravyframe.Configuration;
using Gravyframe.Configuration.Umbraco;
using Gravyframe.Data.News;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Kernel.Umbraco.Tests;
using Gravyframe.Kernel.Umbraco.Tests.Examine;
using Gravyframe.Models.Umbraco;
using Gravyframe.Service;
using Gravyframe.Service.News;
using Gravyframe.ServiceStack.Tests;
using NSubstitute;
using NUnit.Framework;
using ServiceStack.ServiceClient.Web;

namespace Gravyframe.ServiceStack.Umbraco.Tests
{
    [TestFixture]
    public class UmbracoNewsAppHostTests : NewsAppHostTests<UmbracoNews>
    {
        private class TestNewsAppHostConfigurationStrategy : NewsAppHostConfigurationStrategy
        {
            private readonly MockedIndex _mockedIndex;
            private readonly INodeFactoryFacade _nodeFactoryFacade;

            public TestNewsAppHostConfigurationStrategy(MockedIndex mockedIndex, INodeFactoryFacade nodeFactoryFacade)
            {
                _mockedIndex = mockedIndex;
                _nodeFactoryFacade = nodeFactoryFacade;
            }

            public override void ConfigureContainer(Container container)
            {
                container.Register(_mockedIndex.Searcher);
                container.Register(_nodeFactoryFacade);
                container.Register<INewsConfiguration>(
                    new UmbracoNewsConfiguration(container.Resolve<INodeFactoryFacade>(), 1));

                container.Register<NewsDao<UmbracoNews>>(new UmbracoNewsDao(container.Resolve<INewsConfiguration>(),
                    container.Resolve<INodeFactoryFacade>(), container.Resolve<ISearcher>()));

                container.Register<IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>>>(
                    new NewsResponseHydrogenationTaskList(container)
                    );
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
               .Mock(1);

            nodeFactoryFacade.GetNode(1).Returns(mockNode);

            mockedIndex.Indexer.RebuildIndex();

            ConfigurationStrategy = new TestNewsAppHostConfigurationStrategy(mockedIndex, nodeFactoryFacade);

            Sut = new UmbracoNewsAppHostHttpListener(ConfigurationStrategy);
            Sut.Init();
            Sut.Start(ListeningOn);

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
