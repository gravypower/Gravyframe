using System.Linq;
using Gravyframe.Data.InMemory.Content;
using NUnit.Framework;

namespace Gravyframe.Data.InMemory.Tests
{
    [TestFixture]
    public class InMemoryContentDaoTests
    {
        [Test]
        public void SomeTest()
        {
            // Assign
            var sut = new InMemoryContentDao();
            var categoryId = "SomeCategoryId";

            // act
            var result = sut.GetContentByCategory(categoryId);

            // Assert
            Assert.IsTrue(result.Any());
        }
    }
}
