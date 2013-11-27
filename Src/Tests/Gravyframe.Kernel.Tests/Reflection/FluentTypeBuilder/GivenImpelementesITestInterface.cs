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
            var result = Sut
                .CreateType()
                .CreateInstance();
            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterface)));
            Assert.That(result, Is.AssignableTo<ITestInterface>());
        }

        [Test]
        public void CanCreateWithInterfaceTypeNotGeneric()
        {
            var result = this.Sut
                .Implementes(typeof(ITestInterface))
                .CreateInterface();

            Assert.That(result.Type.IsInterface, Is.True);
            Assert.That(result.Type.GetInterfaces(), Has.Some.EqualTo(typeof(ITestInterface)));
        }

        [Test]
        public void CanCreateInterfaceTypeThatImpelementesITestInterface()
        {
            var result = this.Sut.CreateInterface();

            Assert.That(result.Type.IsInterface, Is.True);
            Assert.That(result.Type.GetInterfaces(), Has.Some.EqualTo(typeof(ITestInterface)));
        }
    }
}
