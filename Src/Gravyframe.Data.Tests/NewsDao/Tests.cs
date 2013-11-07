using System.Collections.Generic;
using System.Linq;
using Gravyframe.Data.News;
using NUnit.Framework;

namespace Gravyframe.Data.Tests.NewsDao
{
    [TestFixture]
    public abstract partial class Tests<TNews> where TNews : Models.News
    {
        public NewsDao<TNews> Sut;

        public void GetNewsByCategoryListIsDefaultSizeAssert(IEnumerable<TNews> result)
        {
            // Assert
            Assert.AreEqual(Sut.NewsConfiguration.DefaultListSize, result.Count());
        }

        public void GetNewByCategoryWithCustomListSizeAssert(int listSize, IEnumerable<TNews> result)
        {
            // Assert
            Assert.AreEqual(listSize, result.Count());
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeFirstPageAssert(IEnumerable<TNews> result)
        {
           // Assert
           AssertNewsListSequence(result, new[] { 1, 2, 3, 4, 5 });
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeSecondPageAssert(IEnumerable<TNews> result)
        {
            // Assert
            AssertNewsListSequence(result, new[] { 6, 7, 8, 9, 10 });
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeThirdPageAssert(IEnumerable<TNews> result)
        {
            // Assert
            AssertNewsListSequence(result, new[] { 11, 12, 13, 14, 15 });
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeForthPageAssert(IEnumerable<TNews> result)
        {
            // Assert
            AssertNewsListSequence(result, new[] { 16, 17, 18, 19, 20 });
        }

        public void AssertNewsListSequence(IEnumerable<TNews> result, IEnumerable<int> sequenceNumbers)
        {
            var newsList = result.ToList();
            foreach (var sequenceNumber in sequenceNumbers)
            {
                Assert.IsTrue(newsList.Any(n => n.Sequence == sequenceNumber));
            }
        }

        [Test]
        public void CanGetNewByNewsIdAssert(TNews result)
        {
            // Assert
            Assert.NotNull(result);
        }



        protected abstract string GetExampleSiteId();

        protected abstract string GetExampleCategoryId();

        protected abstract string GetExampleId();

        protected abstract void MockExampleNode();
    }
}
