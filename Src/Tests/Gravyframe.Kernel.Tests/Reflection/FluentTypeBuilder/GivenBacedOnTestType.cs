namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder
{
    using Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder.Artifacts;

    using NUnit.Framework;

    [TestFixture]
    public class GivenBacedOnTestType : FluentTypeBuilderTests
    {
        [SetUp]
        public void GivenBacedOnTestTypeSetUp()
        {
            this.Sut.BaseTypeOf<TestType>();
        }

        [Test]
        public void CanCreateWithBaseType()
        {
            var result = this.Sut.CreateType();

            Assert.That(this.Sut.BaseType, Is.EqualTo(typeof(TestType)));
            Assert.That(result, Is.AssignableFrom<TestType>());
        }

        [Test]
        public void CanCreateWithBaseTypeAndITestInterface()
        {
            var result = this.Sut
                .Implementes<ITestInterface>()
                .CreateType();

            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterface)));
            Assert.That(result, Is.AssignableFrom<ITestInterface>());
            Assert.That(this.Sut.BaseType, Is.EqualTo(typeof(TestType)));
            Assert.That(result, Is.AssignableFrom<TestType>());
        }
    }
}
