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
    using System.Collections;
    using System.Collections.Generic;

    using Lucene.Net.Documents;
    using Lucene.Net.Index;

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

            var mockedParent = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteName").Mock(10);

            var mockedNode = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);

            nodeFactoryFacade.GetNode(90).Returns(mockedNode);

            var sut = new Indexer(
                mockedIndex.IndexCriteria,
                mockedIndex.LuceneDir,
                dataService,
                mockedIndex.Analyzer,
                false,
                nodeFactoryFacade);

            sut.IndexAll("test");


            var feilds = new Dictionary<string, string>();
            var reader = IndexReader.Open(mockedIndex.LuceneDir, true);
            for (var i = 0; i < reader.MaxDoc(); i++)
            {
                if (reader.IsDeleted(i)) continue;

                var doc = reader.Document(i);
                foreach (var field in doc.GetFields().Cast<Field>())
                    feilds.Add(field.Name(), doc.Get(field.Name()));
            }

            Assert.Contains("site", feilds.Keys);
            Assert.AreEqual("SiteName", feilds["site"]);
        }
    }
}
