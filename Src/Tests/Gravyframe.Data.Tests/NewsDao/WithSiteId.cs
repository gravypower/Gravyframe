using NUnit.Framework;

namespace Gravyframe.Data.Tests.NewsDao
{
    public abstract partial class Tests<TNews> where TNews : Models.News
    {
        [Test]
        public virtual void GetNewsByCategoryListIsDefaultSizeWithSiteId()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var siteId = GetExampleSiteId();

            // Act
            var result = Sut.GetNewsByCategoryId(siteId, categoryId);

            // Assert
            GetNewsByCategoryListIsDefaultSizeAssert(result);
        }

        [Test]
        public virtual void GetNewByCategoryWithCustomListSizeWithSiteId()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;
            var siteId = GetExampleSiteId();

            // Act
            var result = Sut.GetNewsByCategoryId(siteId, categoryId, listSize);

            // Assert
            GetNewByCategoryWithCustomListSizeAssert(listSize, result);
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeFirstPageWithSiteId()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;
            var siteId = GetExampleSiteId();

            // Act
            var result = Sut.GetNewsByCategoryId(siteId, categoryId, listSize, 1);

            // Assert
            GetNewsByCategoryIdCustomListSizeFirstPageAssert(result);
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeSecondPageWithSiteId()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;
            var siteId = GetExampleSiteId();

            // Act
            var result = Sut.GetNewsByCategoryId(siteId, categoryId, listSize, 2);

            // Assert
            GetNewsByCategoryIdCustomListSizeSecondPageAssert(result);
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeThirdPageWithSiteId()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;
            var siteId = GetExampleSiteId();

            // Act
            var result = Sut.GetNewsByCategoryId(siteId, categoryId, listSize, 3);

            // Assert
            GetNewsByCategoryIdCustomListSizeThirdPageAssert(result);
        }

        [Test]
        public virtual void GetNewsByCategoryIdCustomListSizeForthPageWithSiteId()
        {
            // Assign
            var categoryId = GetExampleCategoryId();
            var listSize = 5;
            var siteId = GetExampleSiteId();

            // Act
            var result = Sut.GetNewsByCategoryId(siteId, categoryId, listSize, 4);

            // Assert
            GetNewsByCategoryIdCustomListSizeForthPageAssert(result);
        }

        [Test]
        public void CanGetNewByNewsIdWithSiteId()
        {
            // Assign
            MockExampleNode();
            var newsId = GetExampleId();
            var siteId = GetExampleSiteId();

            // Act
            var result = Sut.GetNews(siteId, newsId);

            // Assert
            CanGetNewByNewsIdAssert(result);
        }
    }
}
