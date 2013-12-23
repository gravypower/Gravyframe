namespace Gravyframe.Data.EPiServer.Tests.EPiServerNewsDao
{
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Models.EPiServer;

    using NUnit.Framework;

    public class Tests : Tests<EPiServerNews>
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
