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
    public class ContentServiceTests : ServiceTests<ContentRequest, ContentResponse, ContentService, ContentService.NullContentRequestException>
    {
        public IContentDao Dao;
        public IContentConstants ContentConstants;

        protected override void ServiceSetUp()
        {
            Dao = Substitute.For<IContentDao>();
            ContentConstants = new ContentConstants();
            Sut = new ContentService(Dao, ContentConstants);
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

        #region Given Content Request With Content Category Id

        [TestFixture]
        public class GivenContentRequestWithContentCategoryId : ContentServiceTests
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
