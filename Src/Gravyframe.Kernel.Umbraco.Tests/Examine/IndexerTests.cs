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
        public void IndexerTestsSetUp()
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

        [TestFixture]
        public class WhenOneNodeAndOneSite : IndexerTests
        {
            [SetUp]
            public void WhenOneNodeAndOneSiteSetUp()
            {
                var mockedParent = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteName").Mock(10);
                var mockedNode = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);

                this.NodeFactoryFacade.GetNode(mockedNode.Id).Returns(mockedNode);

                this.MockedContentService.AddNode(mockedNode);
                this.DataService.ContentService.Returns(this.MockedContentService);
            }

            [Test]
            public void DoesIncludeSiteFeild()
            {
                // Act
                this.Sut.IndexAll("test");

                // Assert
                var feilds = this.GetFeildsFromDocumnet();

                Assert.Contains("site", feilds.Keys);
                Assert.Contains("SiteName", feilds["site"]);
            }
        }

        [TestFixture]
        public class WhenTwoNodeAndOneSite : IndexerTests
        {
            [SetUp]
            public void WhenOneNodeAndOneSiteSetUp()
            {
                var mockedParent = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteName").Mock(10);
                var mockedNodeOne = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);
                var mockedNodeTwo = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(91);

                this.NodeFactoryFacade.GetNode(mockedNodeOne.Id).Returns(mockedNodeOne);
                this.NodeFactoryFacade.GetNode(mockedNodeTwo.Id).Returns(mockedNodeTwo);

                this.MockedContentService.AddNode(mockedNodeOne);
                this.MockedContentService.AddNode(mockedNodeTwo);

                this.DataService.ContentService.Returns(this.MockedContentService);
            }

            [Test]
            public void DoesIncludeSiteFeild()
            {
                // Act
                this.Sut.IndexAll("test");

                // Assert
                var feilds = this.GetFeildsFromDocumnet();

                Assert.Contains("site", feilds.Keys);
                Assert.Contains("SiteName", feilds["site"]);
            }
        }

        [TestFixture]
        public class WhenTwoNodeAndTwoSite : IndexerTests
        {
            [SetUp]
            public void WhenOneNodeAndOneSiteSetUp()
            {
                var mockedParentOne = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteNameOne").Mock(10);
                var mockedParentTwo = new MockNode().AddNodeTypeAlias("Site").AddUrlName("SiteNameTwo").Mock(11);
                var mockedNodeOne = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParentOne).Mock(90);
                var mockedNodeTwo = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParentTwo).Mock(91);

                this.NodeFactoryFacade.GetNode(mockedNodeOne.Id).Returns(mockedNodeOne);
                this.NodeFactoryFacade.GetNode(mockedNodeTwo.Id).Returns(mockedNodeTwo);

                this.MockedContentService.AddNode(mockedNodeOne);
                this.MockedContentService.AddNode(mockedNodeTwo);

                this.DataService.ContentService.Returns(this.MockedContentService);
            }

            [Test]
            public void DoesIncludeSiteFeild()
            {
                // Act
                this.Sut.IndexAll("test");

                // Assert
                var feilds = this.GetFeildsFromDocumnet();

                Assert.Contains("site", feilds.Keys);
                Assert.Contains("SiteNameOne", feilds["site"]);
                Assert.Contains("SiteNameTwo", feilds["site"]);
            }
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
