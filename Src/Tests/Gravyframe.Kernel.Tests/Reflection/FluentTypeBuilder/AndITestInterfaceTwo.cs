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
            var result = this.Sut
                .CreateType()
                .CreateInstance();

            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterface)));
            Assert.That(result, Is.AssignableTo<ITestInterface>());
            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterfaceTwo)));
            Assert.That(result, Is.AssignableTo<ITestInterfaceTwo>());
        }

        [Test]
        public void CanCreateInterfaceTypeThatImpelementesITestInterfaceAndITestInterfaceTwo()
        {
            var result = this.Sut.CreateInterface();

            Assert.That(result.Type.IsInterface, Is.True);
            Assert.That(result.Type.GetInterfaces(), Has.Some.EqualTo(typeof(ITestInterface)));
            Assert.That(result.Type.GetInterfaces(), Has.Some.EqualTo(typeof(ITestInterfaceTwo)));
        }
    }
}
