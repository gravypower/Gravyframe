namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder
{
    using Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder.Artifacts;

    using NUnit.Framework;

    [TestFixture]
    public class AndITestInterfaceTwo : GivenImpelementesITestInterface
    {
        [SetUp]
        public void AndITestInterfaceTwoSetUp()
        {
            this.Sut.Implementes<ITestInterfaceTwo>();
        }

        [Test]
        public void CanCreateTypeThatImpelementesBothITestInterfaceAndITestInterfaceTwo()
        {
            var result = this.Sut.CreateType();

            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterfaceTwo)));
            Assert.That(result, Is.AssignableFrom<ITestInterfaceTwo>());
            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterfaceTwo)));
            Assert.That(result, Is.AssignableFrom<ITestInterfaceTwo>());
        }
    }
}
