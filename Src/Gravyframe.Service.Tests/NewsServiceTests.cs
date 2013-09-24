﻿using System.Collections.Generic;
using System.Linq;
using Gravyframe.Data.News;
using Gravyframe.Service.Messages;
using Gravyframe.Service.News;
using Gravyframe.Service.News.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class NewsServiceTests : ServiceTests<NewsRequest, NewsResponse, NewsService, NewsService.NullNewsRequestException>
    {
        public INewsDao Dao;
        public INewsConstants NewsConstants;
        public IEnumerable<ResponseHydrator<NewsRequest, NewsResponse>> ResponseHydratationTasks;

        [SetUp]
        protected override void ServiceSetUp()
        {
            Dao = Substitute.For<INewsDao>();
            NewsConstants = new NewsConstants();

            ResponseHydratationTasks = new List<ResponseHydrator<NewsRequest, NewsResponse>>
                {
                    new PopulateNewsByIdResponseHydrator(NewsConstants, Dao)
                };

            Sut = new NewsService(ResponseHydratationTasks);
        }

        #region Given News Request With No News Id

        [TestFixture]
        public class GivenContentRequestWithNoNewstId : NewsServiceTests
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

        #region Given Content Request With News Id

        [TestFixture]
        public class GivenContentRequestWithNewsId : NewsServiceTests
        {
            public NewsRequest Request;

            [SetUp]
            public void GivenContentRequestWithContentIdSetUp()
            {
                Request = new NewsRequest { NewsId = "SomeID" };
            }

            [Test]
            public void WhenContentRequestContentIdContentResponceSuccess()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.AreEqual(ResponceCodes.Success, responce.Code);
            }

            [Test]
            public void WhenContentRequestedContentIdContentResponceHasContentTitle()
            {
                // Assign
                var news = new Models.News { Title = "TestTitle" };
                Dao.GetNews(Request.NewsId).Returns(news);

                // Act
                var result = Sut.Get(Request);

                // Assert
                Assert.AreEqual(news.Title, result.News.Title);
            }

            [Test]
            public void WhenContentRequestedContentIdContentResponceHasContentBody()
            {
                // Assign
                var news = new Models.News { Body = "TestBody" };
                Dao.GetNews(Request.NewsId).Returns(news);

                // Act
                var result = Sut.Get(Request);

                // Assert
                Assert.AreEqual(news.Body, result.News.Body);
            }
        }
        #endregion
    }
}
