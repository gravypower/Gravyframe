using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gravyframe.Service.Content;
using Gravyframe.Service.Messages;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class ContentServiceTests
    {
        public ContentService Sut;

        [SetUp]
        public void BaseSetUp()
        {
            Sut = new ContentService();
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
            // Assign
            ContentRequest request = null;

            // Assert
            Assert.Throws<ContentService.NullContentRequestException>(() => Sut.Get(request));
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

        [Test]
        public void WhenContentRequestContentIdContentResponceSuccess()
        {
            // Assign
            var request = new ContentRequest { ContentId = "SomeID" };

            // Act
            var responce = Sut.Get(request);

            // Assert
            Assert.AreEqual(AcknowledgeType.Success, responce.Acknowledge);
        }
    }
}
