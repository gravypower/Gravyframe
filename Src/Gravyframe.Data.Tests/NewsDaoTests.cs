using System.Linq;
using Gravyframe.Data.News;
using NUnit.Framework;

namespace Gravyframe.Data.Tests
{
    [TestFixture]
    public abstract class NewsDaoTests<TNews> where TNews : Models.News
    {
        public NewsDao<TNews> Sut;

        [Test]
        public virtual void GetNewsByCategoryListIsDefaultSize()
        {
            // Assign
            var categoryId = GetExampleCategoryId();

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId);

            // Assert
            Assert.AreEqual(Sut.NewsConstants.DefaultListSize, result.Count());
        }

        [Test]
        public virtual void GetNewByCategoryWithCustomListSize()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize);

            // Assert
            Assert.AreEqual(listSize, result.Count());
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeFirstPage()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
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
        public virtual void GetNewsByCategoryIdCustomListSizeSecondPage()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
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
        public virtual void GetNewsByCategoryIdCustomListSizeThirdPage()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
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
        public virtual void GetNewsByCategoryIdCustomListSizeForthPage()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
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
            var newsId = GetExampleId();

            // Act
            var result = Sut.GetNews(newsId);

            // Assert
            Assert.NotNull(result);
        }

        protected abstract string GetExampleCategoryId();

        protected abstract string GetExampleId();
    }
}
