namespace Gravyframe.Data.InMemory.Tests.InMemoryNewsDao
{
    using Gravyframe.Configuration;
    using Gravyframe.Data.InMemory.News;
    using Gravyframe.Data.Tests.NewsDao;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class Tests : Tests<Models.News>
    {
        private INewsConfiguration _newsConfiguration;

        [SetUp]
        public void Setp()
        {
            this._newsConfiguration = Substitute.For<NewsConfiguration>();
            this.Sut = new InMemoryNewsDao(this._newsConfiguration);
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