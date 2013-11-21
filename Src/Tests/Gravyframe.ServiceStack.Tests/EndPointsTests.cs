namespace Gravyframe.ServiceStack.Tests
{
    using System;
    using System.Linq;

    using Funq;

    using global::ServiceStack.Common;
    using global::ServiceStack.ServiceHost;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class EndPointsTests
    {
        public class TestService
        {
            
        }

        public class TestAutomaticServiceWiringConfigurationStrategy : IAutomaticServiceWiringConfigurationStrategy
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

        public class TestConfigurationStrategy : IConfigurationStrategy
        {
            public void ConfigureContainer(Container container)
            {

            }

            public void ConfigureRoutes(IServiceRoutes routes)
            {
            }
        }


        public EndPoint Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = new EndPoint();
        }


        [Test]
        public void AutomaticServiceWiringFindsTestAutomaticServiceWiringConfigurationStrategy()
        {
            Sut.Create();

            Assert.That(
                Sut.ConfigurationStrategies,
                Is.All.AssignableFrom<TestAutomaticServiceWiringConfigurationStrategy>());
        }

        [Test]
        public void CanAddExtraConfigurationStrategy()
        {
            var testConfigurationStrategy = new TestConfigurationStrategy();
            Sut = new EndPoint();

            Sut.AddEndPoint(typeof(TestService).Assembly, testConfigurationStrategy);

            Assert.That(
                Sut.ConfigurationStrategies,
                Has.Some.AssignableFrom<TestConfigurationStrategy>());

            Assert.That(
                Sut.ConfigurationStrategies,
                Has.Some.AssignableFrom<TestAutomaticServiceWiringConfigurationStrategy>());
        }

        [Test]
        public void CanDisableAutomaticServiceWiring()
        {
            var endPointConfiguration = new EndPointConfiguration { AutomaticServiceWiringEnabled = false };
            Sut = new EndPoint(endPointConfiguration);

            Assert.That(Sut.ConfigurationStrategies, Is.Empty);
        }
    }
}
