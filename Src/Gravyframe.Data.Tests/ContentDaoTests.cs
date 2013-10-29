namespace Gravyframe.Data.Tests
{
    using System.Linq;

    using Gravyframe.Data.Content;

    using NUnit.Framework;

    public abstract class ContentDaoTests<TContent> where TContent : Models.Content
    {
        public ContentDao<TContent> Sut;

        [Test]
        public void GetContentByContentId()
        {
            // Assign
            var contentId = GetExampleId();

            // act
            var result = Sut.GetContent(contentId);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetContentByCategoryId()
        {
            // Assign
            var categoryId = GetExampleCategoryId();

            // act
            var result = Sut.GetContentByCategory(categoryId);

            // Assert
            Assert.IsTrue(result.Any());
        }

        protected abstract string GetExampleCategoryId();

        protected abstract string GetExampleId();
    }
}
