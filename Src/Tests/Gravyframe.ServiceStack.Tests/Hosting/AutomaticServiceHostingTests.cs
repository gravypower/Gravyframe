namespace Gravyframe.ServiceStack.Tests.Hosting
{
    using Gravyframe.ServiceStack.Hosting;

    using NUnit.Framework;

    [TestFixture]
    public class AutomaticServiceHostingTests<TConfigurationStrategy>
        where TConfigurationStrategy : IAutomaticServiceHostingConfigurationStrategy
    {
        public AutomaticServiceHosting<TConfigurationStrategy> Sut;

        [Test]
        public void CanFindTypeThatIsAssignableToIAutomaticServiceHostingConfigurationStrategy()
        {
            Assert.That(this.Sut.ConfigurationStrategies, Is.Not.Empty);
            Assert.That(
                this.Sut.ConfigurationStrategies,
                Has.All.AssignableTo<IAutomaticServiceHostingConfigurationStrategy>());
        }

        [Test]
        public void CanFindTypeThatIsAssignableToIConfigurationStrategy()
        {
            Assert.That(this.Sut.ConfigurationStrategies, Is.Not.Empty);
            Assert.That(this.Sut.ConfigurationStrategies, Has.All.AssignableTo<IConfigurationStrategy>());
        }
    }
}
