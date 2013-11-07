namespace Gravyframe.Data.Tests.ContentDao
{
    using System.Linq;

    using Gravyframe.Data.Content;

    using NUnit.Framework;

    public abstract class Tests<TContent> where TContent : Models.Content
    {
        public ContentDao<TContent> Sut;

        [Test]
        public void GetContentByContentId()
        {
            // Assign
            var contentId = this.GetExampleId();

            // act
            var result = this.Sut.GetContent(contentId);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetContentByCategoryId()
        {
            // Assign
            var categoryId = this.GetExampleCategoryId();

            // act
            var result = this.Sut.GetContentByCategory(categoryId);

            // Assert
            Assert.IsTrue(result.Any());
        }

        protected abstract string GetExampleCategoryId();

        protected abstract string GetExampleId();
    }
}
