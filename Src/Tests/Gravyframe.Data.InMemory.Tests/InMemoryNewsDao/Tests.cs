namespace Gravyframe.Data.InMemory.Tests.InMemoryNewsDao
{
    using Gravyframe.Configuration;
    using Gravyframe.Data.InMemory.News;
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Models;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class Tests : Tests<INews>
    {
        private INewsConfiguration _newsConfiguration;

        private class TestContext : INewsDaoTestContext<INews>
        {
            public Data.News.NewsDao<INews> Sut { get; private set; }

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