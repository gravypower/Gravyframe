using System.Collections.Generic;
using System.Linq;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Service.Messages;
using Gravyframe.Service.News;
using Gravyframe.Service.News.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class NewsServiceTests : ServiceTests<NewsRequest, NewsResponse<Models.News>, NewsService<Models.News>, NewsService<Models.News>.NullNewsRequestException>
    {
        public NewsDao<Models.News> Dao;
        public INewsConfiguration NewsConfiguration;
        public IEnumerable<ResponseHydrator<NewsRequest, NewsResponse<Models.News>>> ResponseHydrogenationTasks;

        [SetUp]
        protected override void ServiceSetUp()
        {
            Dao = Substitute.For<NewsDao<Models.News>>();
            NewsConfiguration = new NewsConfiguration();

            ResponseHydrogenationTasks = new List<ResponseHydrator<NewsRequest, NewsResponse<Models.News>>>
                {
                    new PopulateNewsByIdResponseHydrator<Models.News>(Dao, NewsConfiguration),
                    new PopulateNewsByCategoryIdResponseHydrator<Models.News>(Dao, NewsConfiguration)
                };

            Sut = new NewsService<Models.News>(ResponseHydrogenationTasks);
        }

        #region Given News Request With No News Id

        [TestFixture]
        public class GivenNewsRequestWithNoNewstId : NewsServiceTests
        {
            public NewsRequest Request;

            [SetUp]
            public void GivenNewsRequestWithNoNewsIdSetUp()
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
                Assert.IsTrue(responce.Errors.Any(error => error == NewsConfiguration.NewsIdError));
            }
        }
        #endregion

        #region Given News Request With News Id

        [TestFixture]
        public class GivenNewsRequestWithNewsId : NewsServiceTests
        {
            public NewsRequest Request;

            [SetUp]
            public void GivenNewsRequestWithNewsIdSetUp()
            {
                Request = new NewsRequest { NewsId = "SomeID" };
            }

            [Test]
            public void WhenNewsRequestNewsIdNewsResponceSuccess()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.AreEqual(ResponceCodes.Success, responce.Code);
            }

            [Test]
            public void WhenNewsRequestedNewsIdNewsResponceHasTitle()
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
            public void WhenNewsRequestedNewsIdNewsResponceHasBody()
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

        #region Given News Request With News Category Id

        [TestFixture]
        public class GivenNewsRequestWithNewsCategoryId : NewsServiceTests
        {
            public NewsRequest Request;

            [SetUp]
            public void GivenNewsRequestWithNewsCategoryIdSetUp()
            {
                Request = new NewsRequest { CategoryId = "SomeCategoryID" };
            }

            [Test]
            public void WhenNewsRequestCategoryIdAndNoNewsIdNoErrors()
            {
                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.IsFalse(responce.Errors.Any());
            }

            [Test]
            public void WhenNewsRequestCategoryIdNewsResponceHasListOfNews()
            {
                // Assign
                var newsList = new List<Models.News>
                    {
                        new Models.News {Title = "Test Body", Body = "Test Body"},
                        new Models.News {Title = "Test Body1", Body = "Test Body1"}
                    };

                Dao.GetNewsByCategoryId(Request.CategoryId).Returns(newsList);

                // Act
                var responce = Sut.Get(Request);

                // Assert
                Assert.IsTrue(responce.NewsList.Any());
                Assert.IsTrue(responce.NewsList.Any(news => news == newsList[0]));
                Assert.IsTrue(responce.NewsList.Any(news => news == newsList[1]));
            }           
        }
        #endregion
    }
}
