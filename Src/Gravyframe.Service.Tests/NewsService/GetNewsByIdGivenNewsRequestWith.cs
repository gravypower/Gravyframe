namespace Gravyframe.Service.Tests.News.Service
{
    using Gravyframe.Service.Messages;
    using Gravyframe.Service.News;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public abstract class GetNewsByIdGivenNewsRequestWith : Tests
    {
        public NewsRequest Request;

        public virtual void WhenNewsRequestNewsIdNewsResponseSuccess()
        {
            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponceCodes.Success, response.Code);
        }

        public virtual void WhenNewsRequestNewsIdNeNewsInResponseFailure()
        {
            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponceCodes.Failure, response.Code);
            Assert.Contains(this.NewsConfiguration.NewsIdError, response.Errors);
        }

        public virtual void WhenNewsRequestedNewsIdNewsResponseHasTitle(Models.News news)
        {
            // Act
            var result = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(news.Title, result.News.Title);
        }

        public virtual void WhenNewsRequestedNewsIdNewsResponseHasBody(Models.News news)
        {
            // Act
            var result = this.Sut.Get(this.Request);

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
            this.Request = new NewsRequest { NewsId = "SomeID" };
        }

        [Test]
        public override void WhenNewsRequestNewsIdNewsResponseSuccess()
        {
            // Assign
            var news = new Models.News();
            this.Dao.GetNews(this.Request.NewsId).Returns(news);

            base.WhenNewsRequestNewsIdNewsResponseSuccess();
        }

        [Test]
        public override void WhenNewsRequestNewsIdNeNewsInResponseFailure()
        {
            // Assign
            this.Dao.GetNews(this.Request.NewsId).Returns(default(Models.News));

            base.WhenNewsRequestNewsIdNeNewsInResponseFailure();
        }

        [Test]
        public void WhenNewsRequestedNewsIdNewsResponseHasTitle()
        {
            // Assign
            var news = new Models.News { Title = "TestTitle" };
            this.Dao.GetNews(this.Request.NewsId).Returns(news);

            base.WhenNewsRequestedNewsIdNewsResponseHasTitle(news);
        }

        [Test]
        public void WhenNewsRequestedNewsIdNewsResponseHasBody()
        {
            // Assign
            var news = new Models.News { Body = "TestBody" };
            this.Dao.GetNews(this.Request.NewsId).Returns(news);

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
            this.Request = new NewsRequest { NewsId = "SomeID", SiteId = "TestSite"};
        }

        [Test]
        public override void WhenNewsRequestNewsIdNewsResponseSuccess()
        {
            // Assign
            var news = new Models.News();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);

            base.WhenNewsRequestNewsIdNewsResponseSuccess();
        }

        [Test]
        public override void WhenNewsRequestNewsIdNeNewsInResponseFailure()
        {
            // Assign
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(default(Models.News));

            base.WhenNewsRequestNewsIdNeNewsInResponseFailure();
        }

        [Test]
        public void WhenNewsRequestedNewsIdNewsResponseHasTitle()
        {
            // Assign
            var news = new Models.News { Title = "TestTitle" };
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);

            base.WhenNewsRequestedNewsIdNewsResponseHasTitle(news);
        }

        [Test]
        public void WhenNewsRequestedNewsIdNewsResponseHasBody()
        {
            // Assign
            var news = new Models.News { Body = "TestBody" };
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);

            base.WhenNewsRequestedNewsIdNewsResponseHasBody(news);
        }
    }
    #endregion
}
