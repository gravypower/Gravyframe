﻿using System.Linq;
using Gravyframe.Service.Messages;
using Gravyframe.Service.News;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class NewsServiceTests : ServiceTests<NewsRequest, NewsResponse, NewsService, NewsService.NullNewsRequestException>
    {
        public INewsConstants NewsConstants;

        [SetUp]
        protected override void ServiceSetUp()
        {
            NewsConstants = new NewsConstants();
            Sut = new NewsService(NewsConstants);
        }

        #region Given News Request With No Content Id

        [TestFixture]
        public class GivenContentRequestWithNoContentId : NewsServiceTests
        {
            public NewsRequest Request;

            [SetUp]
            public void GivenContentRequestWithNoContentIdSetUp()
            {
                Request = new NewsRequest();
            }

            [Test]
            public void WhenNewsRequestNoNewsIdNewsResponceFailure()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.AreEqual(ResponceCodes.Failure, responce.Code);
            }

            [Test]
            public void WhenNewsRequestNoNewsIdNewsResponceErrors()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.IsTrue(responce.Errors.Any());
                Assert.IsTrue(responce.Errors.Any(error => error == NewsConstants.NewsIdError));
            }


        }
        #endregion
    }
}
