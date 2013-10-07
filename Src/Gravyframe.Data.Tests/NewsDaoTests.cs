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
        public void GetNewByCategoryWithCustomListSize()
        {
            // Assign
            var categoryId = "categoryId";
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize);

            // Assert
            Assert.AreEqual(listSize, result.Count());
        }

        [Test]
        public void GetNewsByCategoryIDCustomListSizeFirstPage()
        {
            // Assign
            var categoryId = "categoryId";
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize, 1).ToArray();

            // Assert
            Assert.IsTrue(result.Any(n => n.Sequence == 1));
            Assert.IsTrue(result.Any(n => n.Sequence == 2));
            Assert.IsTrue(result.Any(n => n.Sequence == 3));
            Assert.IsTrue(result.Any(n => n.Sequence == 4));
            Assert.IsTrue(result.Any(n => n.Sequence == 5));
        }

        [Test]
        public void GetNewsByCategoryIDCustomListSizeSecondPage()
        {
            // Assign
            var categoryId = "categoryId";
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize, 2).ToArray();

            // Assert
            Assert.IsTrue(result.Any(n => n.Sequence == 6));
            Assert.IsTrue(result.Any(n => n.Sequence == 7));
            Assert.IsTrue(result.Any(n => n.Sequence == 8));
            Assert.IsTrue(result.Any(n => n.Sequence == 9));
            Assert.IsTrue(result.Any(n => n.Sequence == 10));
        }

        [Test]
        public void GetNewsByCategoryIDCustomListSizeThirdPage()
        {
            // Assign
            var categoryId = "categoryId";
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize, 3).ToArray();

            // Assert
            Assert.IsTrue(result.Any(n => n.Sequence == 11));
            Assert.IsTrue(result.Any(n => n.Sequence == 12));
            Assert.IsTrue(result.Any(n => n.Sequence == 13));
            Assert.IsTrue(result.Any(n => n.Sequence == 14));
            Assert.IsTrue(result.Any(n => n.Sequence == 15));
        }

        [Test]
        public void GetNewsByCategoryIDCustomListSizeForthPage()
        {
            // Assign
            var categoryId = "categoryId";
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize, 4).ToArray();

            // Assert
            Assert.IsTrue(result.Any(n => n.Sequence == 16));
            Assert.IsTrue(result.Any(n => n.Sequence == 17));
            Assert.IsTrue(result.Any(n => n.Sequence == 18));
            Assert.IsTrue(result.Any(n => n.Sequence == 19));
            Assert.IsTrue(result.Any(n => n.Sequence == 20));
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
