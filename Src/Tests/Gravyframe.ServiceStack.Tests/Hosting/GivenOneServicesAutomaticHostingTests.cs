namespace Gravyframe.ServiceStack.Tests.Hosting
{
    using Funq;

    using global::ServiceStack.ServiceHost;

    using Gravyframe.ServiceStack.Hosting;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class GivenOneServicesAutomaticHostingTests :
        GivenServicesAutomaticHostingTests<ServiceIAutomaticServiceHostingConfigurationStrategy>
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut = Substitute.For<AutomaticServiceHosting<ServiceIAutomaticServiceHostingConfigurationStrategy>>();
        }

        [Test]
        public void AfterInitialisedAssembliesAreOfTypeServers()
        {
            // Act
            Sut.Initialise();

            // Assert
            foreach (var type in Sut.ServiceAssembly.GetTypes())
            {
                Assert.IsTrue(typeof(Service).IsAssignableFrom(type));
            }
        }
    }

    public class Service
    {
    }

    public class ServiceIAutomaticServiceHostingConfigurationStrategy : IAutomaticServiceHostingConfigurationStrategy
    {
        public System.Type GetServiceType()
        {
            return typeof(Service);
        }

        public void ConfigureContainer(Container container)
        {
        }

        public void ConfigureRoutes(IServiceRoutes routes)
        {
        }
    }
}
