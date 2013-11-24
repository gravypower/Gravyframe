namespace Gravyframe.ServiceStack.Tests.Hosting
{
    using global::ServiceStack.ServiceHost;

    using Gravyframe.ServiceStack.Hosting;

    using NUnit.Framework;

    [TestFixture]
    public abstract class GivenServicesAutomaticHostingTests<TAutomaticServiceHostingConfigurationStrategy> : AutomaticServiceHostingTests<TAutomaticServiceHostingConfigurationStrategy>
        where TAutomaticServiceHostingConfigurationStrategy : IAutomaticServiceHostingConfigurationStrategy
    {
        [Test]
        public void WhenInitialisingExceptionThrown()
        {
            // Assert
            Assert.That(() => Sut.Initialise(), Throws.Nothing);
        }

        [Test]
        public void AfterInitialisedHasAssemblies()
        {
            // Act
            Sut.Initialise();
            
            Assert.That(Sut.ServiceAssembly, Is.Not.Null);
        }

        [Test]
        public void AfterInitialisedAssembliesAreOfTypeIServers()
        {
            // Act
            Sut.Initialise();
            
            // Assert
            foreach (var type in Sut.ServiceAssembly.GetTypes() )
            {
                Assert.IsTrue(typeof(IService).IsAssignableFrom(type));
            }
        }

        [Test]
        public void SomeTEst()
        {
            // Act
            Sut.Initialise();

            Assert.That(Sut.ServiceAssembly.ManifestModule.ScopeName , Is.EqualTo(AutomaticServiceHosting<TAutomaticServiceHostingConfigurationStrategy>.DefaultAssemblyName));
        }
    }
}
