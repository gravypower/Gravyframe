using NUnit.Framework;
using Gravyframe.Kernel.Umbraco.Examine;
using Gravyframe.Kernel.Umbraco.Facades;
using NSubstitute;
using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockIndex;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine
{
    using UmbracoExamine.DataServices;

    [TestFixture]    
    public class IndexerTests
    {
        [Test]
        public void sometest()
        {
           var mockedIndex = MockIndexFactory.GetMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList()
                    .AddIndexField("Test"),
                new[] { "Test" },
                new string[] { },
                new string[] { });

            var contentService = Substitute.For<IContentService>();

            var dataService = Substitute.For<IDataService>();
            dataService.ContentService.Returns(contentService);
            
            var nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            var sut = new Indexer(
                mockedIndex.IndexCriteria,
                mockedIndex.LuceneDir,
                dataService,
                mockedIndex.Analyzer,
                false,
                nodeFactoryFacade);

            sut.RebuildIndex();

            

        }
    }
}
