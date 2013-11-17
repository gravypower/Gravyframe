namespace Gravyframe.Service.Tests.ContentService
{
    using System.Linq;

    using Gravyframe.Service.Content;
    using Gravyframe.Service.Content.Tests;
    using Gravyframe.Service.Messages;

    using NUnit.Framework;

    #region Given Content Request With No Content Id
    [TestFixture]
    public class GivenContentRequestWithNoContentId : Tests
    {
        public ContentRequest Request;

        [SetUp]
        public void GivenContentRequestWithNoContentIdSetUp()
        {
            this.Request = new ContentRequest();
        }

        [Test]
        public void WhenContentRequestNoContentIdContentResponceFailure()
        {
            // Act
            var responce = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponseCodes.Failure, responce.Code);
        }

        [Test]
        public void WhenContentRequestNoContentIdContentResponceErrors()
        {
            // Act
            var responce = this.Sut.Get(this.Request);

            // Assert
            Assert.IsTrue(responce.Errors.Any());
            Assert.IsTrue(responce.Errors.Any(error => error == this.ContentConfiguration.ContentIdError));
        }

        [Test]
        public void WhenContentRequestNoContenCategoryIdContenCategoryResponceErrors()
        {
            // Act
            var responce = this.Sut.Get(this.Request);

            // Assert
            Assert.IsTrue(responce.Errors.Any());
            Assert.IsTrue(responce.Errors.Any(error => error == this.ContentConfiguration.ContentCategoryIdError));
        }

    }
    #endregion
}
