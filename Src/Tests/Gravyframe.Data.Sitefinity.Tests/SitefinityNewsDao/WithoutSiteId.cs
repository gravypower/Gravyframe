namespace Gravyframe.Data.Sitefinity.Tests.SitefinityNewsDao
{
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Models.Sitefinity;

    using NUnit.Framework;


    public class WithoutSiteIdTestContext : TestContext
    {
        public WithoutSiteIdTestContext()
        {
            var exampleId = int.Parse(this.ExampleId);
           
        }
    }

    [TestFixture]
    public class WithoutSiteId : WithoutSiteID<SitefinityNews>
    {
        private WithoutSiteIdTestContext testContext;

        [SetUp]
        public void SetUp_And20NewsItems()
        {
            this.testContext = new WithoutSiteIdTestContext();
        }
    }
}
