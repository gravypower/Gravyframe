namespace Gravyframe.Data.Sitefinity.Tests.SitefinityNewsDao
{
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Models.Sitefinity;

    using NUnit.Framework;

    [TestFixture]
    public class Tests : Tests<SitefinityNews>
    {
        protected TestContext TestContext;

        [SetUp]
        public void SetUp()
        {
            TestContext = new TestContext();
            this.Context = TestContext;
        }
    }
}
