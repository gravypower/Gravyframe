using System.Linq;
using Gravyframe.Data.News;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Data.Tests
{
    [TestFixture]
    public abstract class NewsDaoTests
    {
        public NewsDao Sut;

        [Test]
        public void GetNewsByCategoryListIsDefaultSize()
        {
            // Assign
            var categoryId = "categoryId";

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId);

            // Assert
            Assert.AreEqual(Sut.NewsConstants.DefaultListSize, result.Count());
        }

        [Test]
        public void CanGetNewByNewsId()
        {
            // Assign
            var newsId = "newsId";

            // Act
            var result = Sut.GetNews(newsId);

            // Assert
            Assert.NotNull(result);
        }
    }
}
