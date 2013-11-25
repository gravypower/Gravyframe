namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder
{
    using System.Reflection;

    using Gravyframe.Kernel.Reflection;

    using NUnit.Framework;

    [TestFixture]
    public class FluentTypeBuilderTests
    {
        public FluentTypeBuilder Sut;

        [SetUp]
        public void SetUp()
        {
            this.Sut = new FluentTypeBuilder();
        }

        [Test]
        public void CanCreate()
        {
            // Act
            var result = this.Sut.CreateType();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void TypeAttributesAreDefault()
        {
            // Act
            var result = this.Sut.CreateType();

            // Assert
            Assert.That(
                this.Sut.TypeAttributes,
                Is.EqualTo(
                    TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass
                    | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout));

            Assert.That(result.GetType().IsPublic, Is.True );
            Assert.That(result.GetType().IsClass, Is.True);
            Assert.That(result.GetType().IsAutoClass, Is.True);
            Assert.That(result.GetType().IsAnsiClass, Is.True);
            Assert.That(result.GetType().IsAutoLayout, Is.True);
        }
    }
}
