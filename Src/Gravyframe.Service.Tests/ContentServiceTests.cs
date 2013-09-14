using System;
using System.Linq;
using Gravyframe.Data.Content;
using Gravyframe.Service.Content;
using Gravyframe.Service.Messages;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class ContentServiceTests
    {
        public ContentService Sut;
        public IContentDao Dao;

        [SetUp]
        public void BaseSetUp()
        {
            Dao = Substitute.For<IContentDao>();
            Sut = new ContentService(Dao);
        }

        [Test]
        public void CanCreateContentService()
        {
            // Assert
            Assert.IsNotNull(Sut);
        }

        [Test]
        public void WhenContentRequestIsNullContentRequestThrown()
        {
            // Assert
            Assert.Throws<ContentService.NullContentRequestException>(() => Sut.Get(null));
        }

        [Test]
        public void WhenContentRequestInNotNullNullContentRequestExceptionNotThrown()
        {
            // Assign
            var request = new ContentRequest();

            // Assert
            Assert.DoesNotThrow(() => Sut.Get(request));
        }

        [Test]
        public void WhenContentRequestIsNotNullContentResponceNotNull()
        {
            // Assign
            var request = new ContentRequest();

            // Act
            var responce = Sut.Get(request);

            // Assert
            Assert.IsNotNull(responce);
        }

        #region Given Content Request With No Content Id

        [TestFixture]
        public class GivenContentRequestWithNoContentId : ContentServiceTests
        {
            public ContentRequest Request;

            [SetUp]
            public void NoConteIdSetUp()
            {
                Request = new ContentRequest { ContentId = String.Empty };
            }

            [Test]
            public void WhenContentRequestNoContentIdContentResponceFailure()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.AreEqual(AcknowledgeType.Failure, responce.Acknowledge);
            }

            [Test]
            public void WhenContentRequestNoContentIdContentResponceErrors()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.IsTrue(responce.Errors.Any());
                Assert.IsTrue(responce.Errors.Any(error => error == ContentConstants.ContenIdError));
            }
        }
        #endregion

        #region Given Content Request With Content Id

        [TestFixture]
        public class GivenContentRequestWithContentId : ContentServiceTests
        {
            public ContentRequest Request;

            [SetUp]
            public void ConteIdSetUp()
            {
                Request = new ContentRequest { ContentId = "SomeID" };
            }

            [Test]
            public void WhenContentRequestContentIdContentResponceSuccess()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.AreEqual(AcknowledgeType.Success, responce.Acknowledge);
            }

            [Test]
            public void WhenContentRequestedContentIdContentResponceHasContentTitle()
            {
                // Assign
                var content = new Models.Content {Title = "TestTitle"};
                Dao.GetContent().Returns(content);

                // Act
                var result = Sut.Get(Request);

                // Assert
                Assert.AreEqual(content.Title, result.Content.Title);
            }

            [Test]
            public void WhenContentRequestedContentIdContentResponceHasContentBody()
            {
                // Assign
                var content = new Models.Content {Body = "TestBody"};
                Dao.GetContent().Returns(content);

                // Act
                var result = Sut.Get(Request);

                // Assert
                Assert.AreEqual(content.Body, result.Content.Body);
            }
        }
        #endregion
    }
}
