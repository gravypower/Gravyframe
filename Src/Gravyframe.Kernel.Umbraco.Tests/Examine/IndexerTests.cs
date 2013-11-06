using System.Linq;
using System.Reflection;
using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockContentService;
using NUnit.Framework;
using Gravyframe.Kernel.Umbraco.Examine;
using Gravyframe.Kernel.Umbraco.Facades;
using NSubstitute;
using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockIndex;
using UmbracoExamine;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine
{
    using UmbracoExamine.DataServices;

    [TestFixture]    
    public class IndexerTests
    {
        [SetUp]
        public void SetUp()
        {
            var fields = typeof(BaseUmbracoIndexer).GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            var disableInitializationCheckField = fields.SingleOrDefault(x => x.Name == "DisableInitializationCheck");
            if (disableInitializationCheckField == null)
            {
                Assert.Fail("Could Not Set DisableInitializationCheck");
            }

            disableInitializationCheckField.SetValue(null, true);
        }

        [Test]
        public void sometest()
        {
            var mockedIndex = MockIndexFactory.GetSimpleDataServiceMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList(),
                new[] {"test"},
                new string[] {},
                new string[] {});


            var dataService = Substitute.For<IDataService>();
            dataService.ContentService.Returns(new MockedContentService());

            var nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            var sut = new Indexer(
                mockedIndex.IndexCriteria,
                mockedIndex.LuceneDir,
                dataService,
                mockedIndex.Analyzer,
                false,
                nodeFactoryFacade);

            sut.IndexAll("test");


        }
    }
}
