﻿namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder
{
    using Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder.Artifacts;

    using NUnit.Framework;

    [TestFixture]
    public class GivenBasedOnTestType : FluentTypeBuilderTests
    {
        [SetUp]
        public void GivenBasedOnTestTypeSetUp()
        {
            this.Sut.BaseTypeOf<TestType>();
        }


        [Test]
        public void CanCreateWithBaseType()
        {
            var result = this.Sut
                .CreateType()
                .CreateInstance();

            Assert.That(this.Sut.BaseType, Is.EqualTo(typeof(TestType)));
            Assert.That(result, Is.AssignableTo<TestType>());
        }

        [Test]
        public void CanCreateWithBaseTypeNotGeneric()
        {
            var result = this.Sut
                .BaseTypeOf(typeof(TestType))
                .CreateType()
                .CreateInstance();

            Assert.That(this.Sut.BaseType, Is.EqualTo(typeof(TestType)));
            Assert.That(result, Is.AssignableTo<TestType>());
        }

        [Test]
        public void CanCreateWithBaseTypeAndITestInterface()
        {
            var result = this.Sut
                .Implements<ITestInterface>()
                .CreateType()
                .CreateInstance();

            Assert.That(this.Sut.Interfaces, Has.Member(typeof(ITestInterface)));
            Assert.That(result, Is.AssignableTo<ITestInterface>());
            Assert.That(this.Sut.BaseType, Is.EqualTo(typeof(TestType)));
            Assert.That(result, Is.AssignableTo<TestType>());
        }
    }
}