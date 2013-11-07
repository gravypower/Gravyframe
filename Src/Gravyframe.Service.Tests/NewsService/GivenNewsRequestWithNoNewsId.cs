namespace Gravyframe.Service.Tests.News.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Gravyframe.Service.Content;

    using NSubstitute;

    using NUnit.Framework;

    #region Given Content Request With Content Category Id

    [TestFixture]
    public class GivenContentRequestWithContentCategoryId : Gravyframe.Service.Tests.ContentService.Tests
    {
        public ContentRequest Request;

        [SetUp]
        public void GivenContentRequestWithContentCategoryIdSetUp()
        {
            this.Request = new ContentRequest { CategoryId = "SomeCategoryID" };
        }

        [Test]
        public void WhenContentRequestCategoryIdAndNoContentIdNoErrors()
        {
            // Act
            var responce = this.Sut.Get(this.Request);

            // Assert
            Assert.IsFalse(responce.Errors.Any());
        }

        [Test]
        public void WhenContentRequestCategoryIdContentResponceHasListOfContent()
        {
            // Assign
            var contentList = new List<Models.Content>
                    {
                        new Models.Content {Title = "Test Body", Body = "Test Body"},
                        new Models.Content {Title = "Test Body1", Body = "Test Body1"}
                    };

            this.Dao.GetContentByCategory(this.Request.CategoryId).Returns(contentList);

            // Act
            var responce = this.Sut.Get(this.Request);

            // Assert
            Assert.IsTrue(responce.ContentList.Any());
            Assert.IsTrue(responce.ContentList.Any(content => content == contentList[0]));
            Assert.IsTrue(responce.ContentList.Any(content => content == contentList[1]));
        }
    }
    #endregion
}
