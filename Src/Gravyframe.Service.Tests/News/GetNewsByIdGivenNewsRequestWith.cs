using Gravyframe.Service.Messages;
using Gravyframe.Service.News;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Service.Tests.News
{
    [TestFixture]
    public abstract class GetNewsByIdGivenNewsRequestWith : NewsServiceTests
    {
        public NewsRequest Request;

        public virtual void WhenNewsRequestNewsIdNewsResponseSuccess()
        {
            // Act
            var response = Sut.Get(Request);

            // Assert
            Assert.AreEqual(ResponceCodes.Success, response.Code);
        }

        public virtual void WhenNewsRequestNewsIdNeNewsInResponseFailure()
        {
            // Act
            var response = Sut.Get(Request);

            // Assert
            Assert.AreEqual(ResponceCodes.Failure, response.Code);
            Assert.Contains(NewsConfiguration.NewsIdError, response.Errors);
        }

        public virtual void WhenNewsRequestedNewsIdNewsResponseHasTitle(Models.News news)
        {
            // Act
            var result = Sut.Get(Request);

            // Assert
            Assert.AreEqual(news.Title, result.News.Title);
        }

        public virtual void WhenNewsRequestedNewsIdNewsResponseHasBody(Models.News news)
        {
            // Act
            var result = Sut.Get(Request);

            // Assert
            Assert.AreEqual(news.Body, result.News.Body);
        }
    }

    #region Given News Request With News Id

    public class GivenNewsRequestWithNewsId : GetNewsByIdGivenNewsRequestWith
    {
        [SetUp]
        public void GivenNewsRequestWithNewsIdSetUp()
        {
            Request = new NewsRequest { NewsId = "SomeID" };
        }

        [Test]
        public override void WhenNewsRequestNewsIdNewsResponseSuccess()
        {
            // Assign
            var news = new Models.News();
            Dao.GetNews(Request.NewsId).Returns(news);

            base.WhenNewsRequestNewsIdNewsResponseSuccess();
        }

        [Test]
        public override void WhenNewsRequestNewsIdNeNewsInResponseFailure()
        {
            // Assign
            Dao.GetNews(Request.NewsId).Returns(default(Models.News));

            base.WhenNewsRequestNewsIdNeNewsInResponseFailure();
        }

        [Test]
        public void WhenNewsRequestedNewsIdNewsResponseHasTitle()
        {
            // Assign
            var news = new Models.News { Title = "TestTitle" };
            Dao.GetNews(Request.NewsId).Returns(news);

            base.WhenNewsRequestedNewsIdNewsResponseHasTitle(news);
        }

        [Test]
        public void WhenNewsRequestedNewsIdNewsResponseHasBody()
        {
            // Assign
            var news = new Models.News { Body = "TestBody" };
            Dao.GetNews(Request.NewsId).Returns(news);

            base.WhenNewsRequestedNewsIdNewsResponseHasBody(news);
        }
    }
    #endregion

    #region Given News Request With News Id And Site ID

    public class GivenNewsRequestWithNewsIdAndSiteID : GetNewsByIdGivenNewsRequestWith
    {
        [SetUp]
        public void GivenNewsRequestWithNewsIdSetUp()
        {
            Request = new NewsRequest { NewsId = "SomeID", SiteId = "TestSite"};
        }

        [Test]
        public override void WhenNewsRequestNewsIdNewsResponseSuccess()
        {
            // Assign
            var news = new Models.News();
            Dao.GetNews(Request.SiteId, Request.NewsId).Returns(news);

            base.WhenNewsRequestNewsIdNewsResponseSuccess();
        }

        [Test]
        public override void WhenNewsRequestNewsIdNeNewsInResponseFailure()
        {
            // Assign
            Dao.GetNews(Request.SiteId, Request.NewsId).Returns(default(Models.News));

            base.WhenNewsRequestNewsIdNeNewsInResponseFailure();
        }

        [Test]
        public void WhenNewsRequestedNewsIdNewsResponseHasTitle()
        {
            // Assign
            var news = new Models.News { Title = "TestTitle" };
            Dao.GetNews(Request.SiteId, Request.NewsId).Returns(news);

            base.WhenNewsRequestedNewsIdNewsResponseHasTitle(news);
        }

        [Test]
        public void WhenNewsRequestedNewsIdNewsResponseHasBody()
        {
            // Assign
            var news = new Models.News { Body = "TestBody" };
            Dao.GetNews(Request.SiteId, Request.NewsId).Returns(news);

            base.WhenNewsRequestedNewsIdNewsResponseHasBody(news);
        }
    }
    #endregion
}
