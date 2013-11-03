using Gravyframe.Configuration;
using Gravyframe.Data.InMemory.News;
using Gravyframe.Data.Tests.NewsDao;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Data.InMemory.Tests
{
    [TestFixture]
    public class InMemoryNewsDaoTests : NewsDaoTests<Models.News>
    {
        private INewsConfiguration _newsConfiguration;

        [SetUp]
        public void Setp()
        {
            _newsConfiguration = Substitute.For<NewsConfiguration>();
            Sut = new InMemoryNewsDao(_newsConfiguration);
        }

        protected override string GetExampleId()
        {
            return "ExampleId";
        }

        protected override string GetExampleCategoryId()
        {
            return "categoryId";
        }

        protected override void MockExampleNode()
        {
        }

        protected override string GetExampleSiteId()
        {
            return "InMemorySite";
        }
    }
}