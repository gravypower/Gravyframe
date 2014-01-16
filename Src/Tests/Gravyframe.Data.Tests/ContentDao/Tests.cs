namespace Gravyframe.Data.Tests.ContentDao
{
    using System.Linq;

    using NUnit.Framework;

    public abstract class Tests<TContent> where TContent : Models.Content
    {

        public IContentDaoTestContext<TContent> Context;

        [Test]
        public void GetContentByContentId()
        {
            // Assign
            var contentId = this.Context.ExampleId;

            // act
            var result = this.Context.Sut.GetContent(contentId);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetContentByCategoryId()
        {
            // Assign
            var categoryId = this.Context.ExampleCategoryId;

            // act
            var result = this.Context.Sut.GetContentByCategory(categoryId);

            // Assert
            Assert.IsTrue(result.Any());
        }
    }
}
