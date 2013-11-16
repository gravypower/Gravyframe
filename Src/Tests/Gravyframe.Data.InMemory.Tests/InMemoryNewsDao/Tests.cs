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

        private class TestContext : INewsDaoTestContext<Models.News>
        {
            public Data.News.NewsDao<Models.News> Sut { get; private set; }

            public string ExampleCategoryId
            {
                get { throw new System.NotImplementedException(); }
            }

            public string ExampleId
            {
                get { throw new System.NotImplementedException(); }
            }

            public string ExampleSiteId
            {
                get { throw new System.NotImplementedException(); }
            }

            public TestContext(INewsConfiguration newsConfiguration)
            {
                Sut = new InMemoryNewsDao(newsConfiguration);
            }
        }
            [SetUp]
        public void SetUp()
        {
            this._newsConfiguration = Substitute.For<NewsConfiguration>();
            this.Context = new TestContext(this._newsConfiguration);
        }
    }
}