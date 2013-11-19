using Gravyframe.Service.News;
using NSubstitute;
using NUnit.Framework;
using ServiceStack.ServiceHost;

namespace Gravyframe.ServiceStack.Tests
{
    //[TestFixture]
    //public class NewsAppHostConfigurationStrategyTests
    //{
    //    private class TestNewsAppHostConfigurationStrategy : NewsAppHostConfigurationStrategy
    //    {
    //        public override void ConfigureContainer(Funq.Container container)
    //        {
    //        }
    //    }

    //    protected NewsAppHostConfigurationStrategy Sut;
    //    protected IServiceRoutes ServiceRoutes;

    //    [SetUp]
    //    public void SetUp()
    //    {
    //        Sut = new TestNewsAppHostConfigurationStrategy();
    //        ServiceRoutes = Substitute.For<IServiceRoutes>();
    //    }

    //    [Test]
    //    public virtual void CorrectRoutesAdded()
    //    {

    //        Sut.ConfigureRoutes(ServiceRoutes);

    //        var siteTokenRestPath = "/" + NewsAppHostConfigurationStrategy.SiteIdToken;

    //        ServiceRoutes.Received().Add<NewsRequest>(siteTokenRestPath + Sut.GetNewsServiceRestPath());
    //        ServiceRoutes.Received().Add<NewsRequest>(siteTokenRestPath + Sut.GetNewsByIdNewsServiceRestPath());
    //        ServiceRoutes.Received().Add<NewsRequest>(siteTokenRestPath + Sut.GetNewsServiceRestPath());

    //        ServiceRoutes.Received().Add<NewsRequest>(Sut.GetNewsServiceRestPath());
    //        ServiceRoutes.Received().Add<NewsRequest>(Sut.GetNewsByIdNewsServiceRestPath());
    //        ServiceRoutes.Received().Add<NewsRequest>(Sut.GetNewsServiceRestPath());
    //    }
    //}
}
