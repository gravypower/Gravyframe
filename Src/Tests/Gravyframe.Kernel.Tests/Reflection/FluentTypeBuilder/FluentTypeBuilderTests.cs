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
        public void CanCreateType()
        {
            // Act
            var result = this.Sut.CreateType();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void CanCreateInstance()
        {
            // Act
            var result = this.Sut.CreateInstance();

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

            Assert.That(result.Type.IsPublic, Is.True );
            Assert.That(result.Type.IsClass, Is.True);
            Assert.That(result.Type.IsAutoClass, Is.True);
            //TODO: Need to fulley understand what an Ansi Class is.  
            //I think it has something to do with the format of strings in the class http://msdn.microsoft.com/en-US/library/windowsphone/develop/system.type.isansiclass(v=vs.100).aspx
            //Assert.That(result.Type.IsAnsiClass, Is.True);
            Assert.That(result.Type.IsAutoLayout, Is.True);
        }

        [TestCase("TestName")]
        [TestCase("TestName2")]
        public void TypeCanSetAssemblyName(string name)
        {
            // Act
            var result = this.Sut.SetAssemblyName(name).CreateType();
            Assert.That(result.AssemblyName.Name, Is.EqualTo(name));
        }


        [TestCase("TestName")]
        [TestCase("TestName2")]
        public void TypeCanSetTypeName(string name)
        {
            // Act
            var result = this.Sut.SetTypeName(name).CreateType();
            Assert.That(result.Type.Name, Is.EqualTo(name));
        }

    }
}
