namespace Gravyframe.Service.Tests.ContentService
{
    using System.Linq;

    using Gravyframe.Service.Content;
    using Gravyframe.Service.Messages;

    using NSubstitute;

    using NUnit.Framework;

    #region Given Content Request With Content Id

    [TestFixture]
    public class GivenContentRequestWithContentId : Tests
    {
        public ContentRequest Request;

        [SetUp]
        public void GivenContentRequestWithContentIdSetUp()
        {
            this.Request = new ContentRequest { ContentId = "SomeID" };
        }

        [Test]
        public void WhenContentRequestContentIdContentResponceSuccess()
        {
            // Act
            var responce = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponceCodes.Success, responce.Code);
            Assert.IsFalse(responce.Errors.Any(error => error == this.ContentConfiguration.ContentCategoryIdError));
        }

        [Test]
        public void WhenContentRequestedContentIdContentResponceHasContentTitle()
        {
            // Assign
            var content = new Models.Content { Title = "TestTitle" };
            this.Dao.GetContent(this.Request.ContentId).Returns(content);

            // Act
            var result = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(content.Title, result.Content.Title);
        }

        [Test]
        public void WhenContentRequestedContentIdContentResponceHasContentBody()
        {
            // Assign
            var content = new Models.Content { Body = "TestBody" };
            this.Dao.GetContent(this.Request.ContentId).Returns(content);

            // Act
            var result = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(content.Body, result.Content.Body);
        }
    }
    #endregion
}
