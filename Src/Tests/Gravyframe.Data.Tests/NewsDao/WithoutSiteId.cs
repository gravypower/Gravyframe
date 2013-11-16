using NUnit.Framework;

namespace Gravyframe.Data.Tests.NewsDao
{
    public abstract partial class Tests<TNews> where TNews : Models.News
    {
        [Test]
        public virtual void GetNewsByCategoryListIsDefaultSize()
        {
            // Assign
            var categoryId = GetExampleCategoryId();

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId);

            // Assert
            GetNewsByCategoryListIsDefaultSizeAssert(result);
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
            GetNewByCategoryWithCustomListSizeAssert(listSize, result);
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeFirstPage()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize, 1);

            // Assert
            GetNewsByCategoryIdCustomListSizeFirstPageAssert(result);
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeSecondPage()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize, 2);

            // Assert
            GetNewsByCategoryIdCustomListSizeSecondPageAssert(result);
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeThirdPage()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize, 3);

            // Assert
            GetNewsByCategoryIdCustomListSizeThirdPageAssert(result);
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeForthPage()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;

            // Act
            var result = Sut.GetNewsByCategoryId(categoryId, listSize, 4);

            // Assert
            GetNewsByCategoryIdCustomListSizeForthPageAssert(result);
        }

        [Test]
        public void CanGetNewByNewsId()
        {
            // Assign
            MockExampleNode();
            var newsId = GetExampleId();

            // Act
            var result = Sut.GetNews(newsId);

            // Assert
            CanGetNewByNewsIdAssert(result);
        }
    }
}
