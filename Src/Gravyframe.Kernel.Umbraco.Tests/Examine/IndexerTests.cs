using System.Linq;
using System.Reflection;
using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockContentService;
using NUnit.Framework;
using Gravyframe.Kernel.Umbraco.Examine;
using Gravyframe.Kernel.Umbraco.Facades;
using NSubstitute;
using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockIndex;
using UmbracoExamine;
using System.Collections.Generic;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using UmbracoExamine.DataServices;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine
{
    [TestFixture]    
    public class IndexerTests
    {
        protected INodeFactoryFacade NodeFactoryFacade;

        protected IDataService DataService;

        protected MockedContentService MockedContentService;

        protected Indexer Sut;

        protected MockedIndex MockedIndex;

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

            this.MockedIndex = MockIndexFactory.GetSimpleDataServiceMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList(),
                new[] { "test" },
                new string[] { },
                new string[] { });

            this.NodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            this.DataService = Substitute.For<IDataService>();
            this.MockedContentService = new MockedContentService();

            this.Sut = new Indexer(
                this.MockedIndex.IndexCriteria,
                this.MockedIndex.LuceneDir,
                this.DataService,
                this.MockedIndex.Analyzer,
                false,
                this.NodeFactoryFacade);
        }

        [Test]
        public void DoesIncludeSiteFeild()
        {
           // Assign
            var mockedParent = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteName").Mock(10);
            var mockedNode = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);

            this.NodeFactoryFacade.GetNode(mockedNode.Id).Returns(mockedNode);

            this.MockedContentService.AddNode(mockedNode);
            this.DataService.ContentService.Returns(this.MockedContentService);

            // Act
            this.Sut.IndexAll("test");

            // Assert
            var feilds = this.GetFeildsFromDocumnet();

            Assert.Contains("site", feilds.Keys);
            Assert.AreEqual("SiteName", feilds["site"]);
        }

        private Dictionary<string, string> GetFeildsFromDocumnet()
        {
            var feilds = new Dictionary<string, string>();
            var reader = IndexReader.Open(this.MockedIndex.LuceneDir, true);

            for (var i = 0; i < reader.MaxDoc(); i++)
            {
                var doc = reader.Document(i);
                foreach (var field in doc.GetFields().Cast<Field>())
                {
                    feilds.Add(field.Name(), doc.Get(field.Name()));
                }
            }
            return feilds;
        }
    }
}
