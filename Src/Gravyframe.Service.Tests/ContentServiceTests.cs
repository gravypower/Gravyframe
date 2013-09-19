using System;
using System.Collections.Generic;
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
        public IContentConstants ContentConstants;

        [SetUp]
        public void BaseSetUp()
        {
            Dao = Substitute.For<IContentDao>();
            ContentConstants = new ContentConstants();
            Sut = new ContentService(Dao, ContentConstants);
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
                Request = new ContentRequest();
            }

            [Test]
            public void WhenContentRequestNoContentIdContentResponceFailure()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.AreEqual(GravyResponceCodes.Failure, responce.ResponceCode);
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

            [Test]
            public void WhenContentRequestNoContenCategoryIdContenCategoryResponceErrors()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.IsTrue(responce.Errors.Any());
                Assert.IsTrue(responce.Errors.Any(error => error == ContentConstants.ContenCategoryIdError));
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
                Assert.AreEqual(GravyResponceCodes.Success, responce.ResponceCode);
                Assert.IsFalse(responce.Errors.Any(error => error == ContentConstants.ContenCategoryIdError));
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

        #region Given Content Request With Content Category

        [TestFixture]
        public class GivenContentRequestWithContentCategory : ContentServiceTests
        {
            public ContentRequest Request;

            [SetUp]
            public void ConteIdSetUp()
            {
                Request = new ContentRequest { CategoryId = "SomeCategoryID" };
            }

            [Test]
            public void WhenContentRequestCategoryIdAndNoContentIdNoErrors()
            {
                // Act
                var responce = Sut.Get(Request);

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

                Dao.GetContentByCategory(Request.CategoryId).Returns(contentList);

                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.IsTrue(responce.ContentList.Any());
                Assert.IsTrue(responce.ContentList.Any(content => content == contentList[0]));
                Assert.IsTrue(responce.ContentList.Any(content => content == contentList[1]));

            }
        }
        #endregion
    }
}
