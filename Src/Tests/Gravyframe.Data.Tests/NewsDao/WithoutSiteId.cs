using NUnit.Framework;

namespace Gravyframe.Data.Tests.NewsDao
{
    public abstract class WithoutSiteID<TNews> : Tests<TNews>
        where TNews : Models.News
    {
        [Test]
        public void GetNewsByCategoryListIsDefaultSize()
        {
            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleCategoryId);

            // Assert
            GetNewsByCategoryListIsDefaultSizeAssert(result);
        }

        [Test]
        public void GetNewByCategoryWithCustomListSize()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleCategoryId, listSize);

            // Assert
            GetNewByCategoryWithCustomListSizeAssert(listSize, result);
        }

        [Test]
        public void GetNewsByCategoryIdCustomListSizeFirstPage()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleCategoryId, listSize, 1);

            // Assert
            GetNewsByCategoryIdCustomListSizeFirstPageAssert(result);
        }

        [Test]
        public void GetNewsByCategoryIdCustomListSizeSecondPage()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleCategoryId, listSize, 2);

            // Assert
            GetNewsByCategoryIdCustomListSizeSecondPageAssert(result);
        }

        [Test]
        public void GetNewsByCategoryIdCustomListSizeThirdPage()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleCategoryId, listSize, 3);

            // Assert
            GetNewsByCategoryIdCustomListSizeThirdPageAssert(result);
        }

        [Test]
        public void GetNewsByCategoryIdCustomListSizeForthPage()
        {
            // Assign
            var listSize = 5;

            // Act
            var result = Context.Sut.GetNewsByCategoryId(Context.ExampleCategoryId, listSize, 4);

            // Assert
            GetNewsByCategoryIdCustomListSizeForthPageAssert(result);
        }

        [Test]
        public void CanGetNewByNewsId()
        {
            // Act
            var result = Context.Sut.GetNews(Context.ExampleId);

            // Assert
            CanGetNewByNewsIdAssert(result);
        }
    }
}
