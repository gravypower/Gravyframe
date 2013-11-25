namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder
{
    using Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder.Artifacts;

    using NUnit.Framework;

    [TestFixture]
    public class GivenImpelementesITestInterface : FluentTypeBuilderTests
    {
        [SetUp]
        public void GivenImpelementesITestInterfaceSetUp()
        {
            this.Sut.Implementes<ITestInterface>();
        }

        [Test]
        public void CanCreateTypeThatImpelementesITestInterface()
        {
            var result = Sut.CreateType();
            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterface)));
            Assert.That(result, Is.AssignableFrom<ITestInterface>());
        }
    }
}
