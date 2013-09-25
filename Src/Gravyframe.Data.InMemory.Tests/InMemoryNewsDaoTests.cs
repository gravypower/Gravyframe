using System.Linq;
using Gravyframe.Constants;
using Gravyframe.Data.InMemory.News;
using NUnit.Framework;

namespace Gravyframe.Data.InMemory.Tests
{
    [TestFixture]
    public class InMemoryNewsDaoTests
    {
        private INewsConstants _newsConstants;

        [SetUp]
        public void SetUp()
        {
            _newsConstants = new NewsConstants();
        }

        [Test]
        public void SomeTest()
        {
            // Assign
            var sut = new InMemoryNewsDao(_newsConstants);
            var categoryId = "categoryId";

            // Act
            var result = sut.GetNewsByCategoryId(categoryId);

            // Assert
            Assert.AreEqual(_newsConstants.DefaultListSize, result.Count());
        }
    }
}
