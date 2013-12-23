namespace Gravyframe.Data.EPiServer.Tests.EPiServerNewsDao
{
    using System;

    using global::EPiServer.Core;

    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Models.EPiServer;

    using NSubstitute;

    using NUnit.Framework;

    public class WithoutSiteIdTestContext : TestContext
    {
        public WithoutSiteIdTestContext()
        {
            var exampleId = Guid.Parse(this.ExampleId);
            var content = Substitute.For<IContent>();
            content.ContentGuid.Returns(exampleId);
            this.ContentRepository.Get<IContent>(exampleId).Returns(content);
        }
    }

    [TestFixture]
    public class And20NewsItems_WithoutSiteID : WithoutSiteID<EPiServerNews>
    {
        private WithoutSiteIdTestContext testContext;

        [SetUp]
        public void SetUp_And20NewsItems()
        {
            this.testContext = new WithoutSiteIdTestContext();
            Context = this.testContext;
        }
    }
}
