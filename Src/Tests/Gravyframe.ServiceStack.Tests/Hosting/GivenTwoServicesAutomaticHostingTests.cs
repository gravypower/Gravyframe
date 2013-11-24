namespace Gravyframe.ServiceStack.Tests.Hosting
{
    using System.Linq;

    using Funq;

    using global::ServiceStack.ServiceHost;

    using Gravyframe.ServiceStack.Hosting;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class GivenTwoServicesAutomaticHostingTests : GivenServicesAutomaticHostingTests<IMultipleAutomaticServiceHostingConfigurationStrategy>
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut = Substitute.For<AutomaticServiceHosting<IMultipleAutomaticServiceHostingConfigurationStrategy>>();
        }

        [Test]
        public void AfterInitialisedAssembliesAreOfTypeServiceOneAndServiceTwo()
        {
            // Act
            Sut.Initialise();

            // Assert
            Assert.IsTrue(Sut.ServiceAssembly.GetTypes().Any(type => typeof(ServiceOne).IsAssignableFrom(type)));
            Assert.IsTrue(Sut.ServiceAssembly.GetTypes().Any(type => typeof(ServiceTwo).IsAssignableFrom(type)));
        }
    }

    public interface IMultipleAutomaticServiceHostingConfigurationStrategy : IAutomaticServiceHostingConfigurationStrategy
    { }

    public class ServiceOne
    {
    }

    public class OneAutomaticServiceHostingConfigurationStrategy : IMultipleAutomaticServiceHostingConfigurationStrategy
    {
        public System.Type GetServiceType()
        {
            return typeof(ServiceOne);
        }

        public void ConfigureContainer(Container container)
        {
        }

        public void ConfigureRoutes(IServiceRoutes routes)
        {
        }
    }

    public class ServiceTwo
    {
    }

    public class TwoAutomaticServiceHostingConfigurationStrategy : IMultipleAutomaticServiceHostingConfigurationStrategy
    {
        public System.Type GetServiceType()
        {
            return typeof(ServiceTwo);
        }

        public void ConfigureContainer(Container container)
        {
        }

        public void ConfigureRoutes(IServiceRoutes routes)
        {
        }
    }
}
