namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Gravyframe.Kernel.Umbraco.Examine;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockContentService;
    using Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockIndex;

    using Lucene.Net.Documents;
    using Lucene.Net.Index;

    using NSubstitute;

    using NUnit.Framework;

    using UmbracoExamine;
    using UmbracoExamine.DataServices;

    [TestFixture]    
    public class Tests
    {
        protected INodeFactoryFacade NodeFactoryFacade;
        protected IDataService DataService;
        protected MockedContentService MockedContentService;
        protected Indexer Sut;
        protected MockedIndex MockedIndex;

        [SetUp]
        public void TestsSetUp()
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

        
        protected Dictionary<string, List<string>> GetFeildsFromDocumnet()
        {
            var feilds = new Dictionary<string, List<string>>();
            var reader = IndexReader.Open(this.MockedIndex.LuceneDir, true);

            for (var i = 0; i < reader.MaxDoc(); i++)
            {
                var doc = reader.Document(i);
                foreach (var field in doc.GetFields().Cast<Field>())
                {
                    var feildName = field.Name();
                    if (!feilds.ContainsKey(feildName))
                    {
                        feilds.Add(feildName, new List<string> { doc.Get(feildName) });
                    }
                    else
                    {
                        feilds[feildName].Add(doc.Get(feildName));
                    }
                }
            }
            return
                feilds;
        }
    }
}
