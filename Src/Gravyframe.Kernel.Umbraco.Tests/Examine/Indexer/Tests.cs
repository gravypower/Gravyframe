using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Gravyframe.Kernel.Umbraco.Facades;
using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine.MockContentService;
using Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine.MockIndex;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using NSubstitute;
using NUnit.Framework;
using UmbracoExamine;
using UmbracoExamine.DataServices;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Indexer
{
    [TestFixture]
    public class Tests
    {
        protected INodeFactoryFacade NodeFactoryFacade;
        protected IDataService DataService;
        protected MockedContentService MockedContentService;
        protected Umbraco.Examine.Indexer Sut;
        protected MockedIndex MockedIndex;

        [SetUp]
        public void TestsSetUp()
        {
            var fields = typeof (BaseUmbracoIndexer).GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            var disableInitializationCheckField = fields.SingleOrDefault(x => x.Name == "DisableInitializationCheck");
            if (disableInitializationCheckField == null)
            {
                Assert.Fail("Could Not Set DisableInitializationCheck");
            }

            disableInitializationCheckField.SetValue(null, true);

            MockedIndex = MockIndexFactory.GetSimpleDataServiceMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList(),
                new[] {"test"},
                new string[] {},
                new string[] {});

            NodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            DataService = Substitute.For<IDataService>();
            MockedContentService = new MockedContentService();

            Sut = new Umbraco.Examine.Indexer(
                MockedIndex.IndexCriteria,
                MockedIndex.LuceneDir,
                DataService,
                MockedIndex.Analyzer,
                false,
                NodeFactoryFacade);
        }


        protected Dictionary<string, List<string>> GetFieldsFromDocument()
        {
            var fields = new Dictionary<string, List<string>>();
            var reader = IndexReader.Open(MockedIndex.LuceneDir, true);

            for (var i = 0; i < reader.MaxDoc(); i++)
            {
                var doc = reader.Document(i);
                foreach (var field in doc.GetFields().Cast<Field>())
                {
                    var fieldName = field.Name();
                    if (!fields.ContainsKey(fieldName))
                    {
                        fields.Add(fieldName, new List<string> {doc.Get(fieldName)});
                    }
                    else
                    {
                        fields[fieldName].Add(doc.Get(fieldName));
                    }
                }
            }
            return fields;
        }
    }
}