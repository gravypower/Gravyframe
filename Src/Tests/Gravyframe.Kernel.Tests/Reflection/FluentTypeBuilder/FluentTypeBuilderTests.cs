namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder
{
    using System.Threading;

    using Gravyframe.Kernel.Reflection;

    using NUnit.Framework;

    [TestFixture]
    public class FluentTypeBuilderTests
    {
        public FluentTypeBuilder Sut;

        [SetUp]
        public void SetUp()
        {
            this.Sut = new FluentTypeBuilder(Thread.GetDomain());
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

        [Test]
        public void CanChangeName()
        {
            // Assign
            var name1 = "Test1";
            var name2 = "Test2";

            //Act
            var result1 = this.Sut.SetTypeName(name1).CreateType().Type;
            var result2 = this.Sut.SetTypeName(name2).CreateType().Type;

            // Assert
            Assert.That(result1.Name, Is.EqualTo(name1));
            Assert.That(result2.Name, Is.EqualTo(name2));
        }

        [Test]
        public void CanCreateAnInterface()
        {
            var result = this.Sut.CreateInterface();

            Assert.That(result.Type.IsInterface, Is.True);
        }


        [Test]
        public void CanCreateAnInterfaceInstance()
        {
            var typeBuilder = this.Sut.CreateInterface();
            var result = typeBuilder.CreateInstance();

            Assert.That(result.GetType().IsClass, Is.True);
            Assert.That(result, Is.AssignableTo(typeBuilder.Type));
        }
    }
}
