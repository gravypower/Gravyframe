namespace Gravyframe.ServiceStack.Tests
{
    using System;

    using Funq;

    using global::ServiceStack.ServiceHost;

    using NUnit.Framework;

    [TestFixture]
    public class EndPointsTests
    {
        public class TestService
        {
            
        }

        public class Test : IAutomaticServiceWiringConfigurationStrategy
        {
            public void ConfigureContainer(Container container)
            {
                
            }

            public void ConfigureRoutes(IServiceRoutes routes)
            {
            }

            public Type GetServiceType()
            {
                return typeof(TestService);
            }
        }

        [Test]
        public void SomeTest()
        {
            var endPoint = new EndPoint().Create();
            endPoint.AppHost.Init();
        }
    }
}
