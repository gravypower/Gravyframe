namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder
{
    using Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder.Artifacts;

    using NUnit.Framework;

    [TestFixture]
    public class GivenImplementsITestInterfaceTwo : FluentTypeBuilderTests
    {
        [SetUp]
        public void GivenImplementsITestInterfaceTwoSetUp()
        {
            this.Sut.Implements<ITestInterfaceTwo>();
        }

        [Test]
        public void CanCreateTypeThatImplementsITestInterfaceTwo()
        {
            var result = this.Sut
                .CreateType()
                .CreateInstance();

            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterfaceTwo)));
            Assert.That(result, Is.AssignableTo<ITestInterfaceTwo>());
        }

        [Test]
        public void CanCreateInterfaceTypeThatImplementsITestInterface()
        {
            var result = this.Sut.CreateInterface();

            Assert.That(result.Type.IsInterface, Is.True);
            Assert.That(result.Type.GetInterfaces(), Has.Some.EqualTo(typeof(ITestInterfaceTwo)));
        }
    }
}
