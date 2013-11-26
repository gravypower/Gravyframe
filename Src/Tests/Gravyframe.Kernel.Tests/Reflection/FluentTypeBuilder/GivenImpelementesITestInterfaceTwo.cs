// -----------------------------------------------------------------------
// <copyright file="GivenImpelementesITestInterfaceTwo.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder
{
    using Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder.Artifacts;

    using NUnit.Framework;

    [TestFixture]
    public class GivenImpelementesITestInterfaceTwo : FluentTypeBuilderTests
    {
        [SetUp]
        public void GivenImpelementesITestInterfaceTwoSetUp()
        {
            this.Sut.Implementes<ITestInterfaceTwo>();
        }

        [Test]
        public void CanCreateTypeThatImpelementesITestInterfaceTwo()
        {
            var result = this.Sut
                .CreateType()
                .CreateInstance();

            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterfaceTwo)));
            Assert.That(result, Is.AssignableTo<ITestInterfaceTwo>());
        }
    }
}
