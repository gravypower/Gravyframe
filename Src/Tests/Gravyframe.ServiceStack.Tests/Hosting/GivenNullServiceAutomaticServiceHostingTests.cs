namespace Gravyframe.ServiceStack.Tests.Hosting
{
    using Funq;

    using global::ServiceStack.ServiceHost;

    using Gravyframe.ServiceStack.Hosting;

    using NSubstitute;

    using NUnit.Framework;

    public class GivenNullServiceAutomaticServiceHostingTests :
             AutomaticServiceHostingTests<NullServiceIAutomaticServiceHostingConfigurationStrategy>
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut = Substitute.For<AutomaticServiceHosting<NullServiceIAutomaticServiceHostingConfigurationStrategy>>();
        }

        [Test]
        public void WhenInitialisingExceptionThrown()
        {
            Assert.That(() => Sut.Initialise(), Throws.Exception.TypeOf<AutomaticServiceHosting<NullServiceIAutomaticServiceHostingConfigurationStrategy>.NullServiceTypeException>());
        }

        [Test]
        public void AfterInitialisedNoAssemblies()
        {
            Assert.That(Sut.ServiceAssembly, Is.Null);
        }
    }

    public class NullServiceIAutomaticServiceHostingConfigurationStrategy : IAutomaticServiceHostingConfigurationStrategy
    {
        public System.Type GetServiceType()
        {
            return null;
        }

        public void ConfigureContainer(Container container)
        {
        }

        public void ConfigureRoutes(IServiceRoutes routes)
        {
        }
    }
}
