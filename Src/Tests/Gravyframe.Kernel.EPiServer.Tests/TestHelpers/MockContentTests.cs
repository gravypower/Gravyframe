namespace Gravyframe.Kernel.EPiServer.Tests.TestHelpers
{
    using System;

    using global::EPiServer.Core;

    using NUnit.Framework;

    [TestFixture]
    public class MockContentTests
    {
        public MockContent Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = new MockContent();
        }

        [Test]
        public void CanMockContent()
        {
            var content = Sut.Mock(new Guid("{599F828E-6BEB-11E3-BD72-BD63FB92346D}"));

            Assert.That(content, Is.AssignableTo<IContent>());
        }

        [Test]
        public void CanAddProperty()
        {
            var alias = "TestAlias";
            var value = "TestValue";
            Sut.AddProperty(alias, value);

            var content = Sut.Mock(new Guid("{599F828E-6BEB-11E3-BD72-BD63FB92346D}"));

            Assert.That(content.Property[alias].Value, Is.EqualTo(value));
        }

        [Test]
        public void CanAddTowProperties()
        {
            var alias = "TestAlias";
            var value = "TestValue";

            var alias1 = "TestAlias1";
            var value1 = "TestValue1";
            Sut.AddProperty(alias, value).AddProperty(alias1, value1);

            var content = Sut.Mock(new Guid("{599F828E-6BEB-11E3-BD72-BD63FB92346D}"));

            Assert.That(content.Property[alias].Value, Is.EqualTo(value));
            Assert.That(content.Property[alias1].Value, Is.EqualTo(value1));
        }

        [Test]
        public void CanSetIDWhenMocking()
        {
            var id = new Guid("{599F828E-6BEB-11E3-BD72-BD63FB92346D}");
            var content = Sut.Mock(id);

            Assert.That(content.ContentGuid, Is.EqualTo(id));
        }
    }
}
