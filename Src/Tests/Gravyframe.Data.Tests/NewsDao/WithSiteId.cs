using NUnit.Framework;

namespace Gravyframe.Data.Tests.NewsDao
{
    public abstract class WithSiteID<TNews> : Tests<TNews>
        where TNews : Models.News
    {

        [Test]
        public void GetNewsByCategoryListIsDefaultSizeWithSiteId()
        {
            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleSiteId, Context.ExampleCategoryId);

            // Assert
            GetNewsByCategoryListIsDefaultSizeAssert(result);
        }

        [Test]
        public void GetNewByCategoryWithCustomListSizeWithSiteId()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleSiteId, Context.ExampleCategoryId, listSize);

            // Assert
            GetNewByCategoryWithCustomListSizeAssert(listSize, result);
        }

        [Test]
        public void GetNewsByCategoryIdCustomListSizeFirstPageWithSiteId()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleSiteId, Context.ExampleCategoryId, listSize, 1);

            // Assert
            GetNewsByCategoryIdCustomListSizeFirstPageAssert(result);
        }

        [Test]
        public void GetNewsByCategoryIdCustomListSizeSecondPageWithSiteId()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleSiteId, Context.ExampleCategoryId, listSize, 2);

            // Assert
            GetNewsByCategoryIdCustomListSizeSecondPageAssert(result);
        }

        [Test]
        public void GetNewsByCategoryIdCustomListSizeThirdPageWithSiteId()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleSiteId, Context.ExampleCategoryId, listSize, 3);

            // Assert
            GetNewsByCategoryIdCustomListSizeThirdPageAssert(result);
        }

        [Test]
        public void GetNewsByCategoryIdCustomListSizeForthPageWithSiteId()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleSiteId, Context.ExampleCategoryId, listSize, 4);

            // Assert
            GetNewsByCategoryIdCustomListSizeForthPageAssert(result);
        }

        [Test]
        public void CanGetNewByNewsIdWithSiteId()
        {
            // Act
            var result = Context.Sut.GetNews(Context.ExampleSiteId, Context.ExampleId);

            // Assert
            CanGetNewByNewsIdAssert(result);
        }

    }
}
