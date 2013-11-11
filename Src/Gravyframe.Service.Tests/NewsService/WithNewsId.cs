namespace Gravyframe.Service.Tests.NewsService
{
    using Gravyframe.Models;
    using Gravyframe.Service.Messages;
    using Gravyframe.Service.News;

    using NSubstitute;

    using NUnit.Framework;

    public class WithNewsId : GivenNewsRequest
    {
        #region With News Id
        [SetUp]
        public void WithNewsIdSetUp()
        {
            this.Request = new NewsRequest { NewsId = "SomeID" };
        }

        [Test]
        public void NewsResponseSuccess()
        {
            // Assign 
            this.AssignNewsResponseSuccess();

            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponceCodes.Success, response.Code);
        }
        
        public virtual void AssignNewsResponseSuccess()
        {
            this.News = new News();
            this.Dao.GetNews(this.Request.NewsId).Returns(this.News);
        }

        [Test]
        public void NewsInResponseFailure()
        {
            this.AssignNewsInResponseFailure();

            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponceCodes.Failure, response.Code);
            Assert.Contains(this.NewsConfiguration.NewsIdError, response.Errors);
        }

        public virtual void AssignNewsInResponseFailure()
        {
            this.Dao.GetNews(this.Request.NewsId).Returns(default(News));
        }

        [Test]
        public void NewsResponseHasTitle()
        {
            // Assign
            this.AssignForNewsResponseHasTitle();
            // Act
            var result = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(this.News.Title, result.News.Title);
        }
        public virtual void AssignForNewsResponseHasTitle()
        {
            this.News = new News { Title = "TestTitle" };
            this.Dao.GetNews(this.Request.NewsId).Returns(this.News);
        }

        [Test]
        public void NewsResponseHasBody()
        {
            // Assign
            this.AssignForNewsResponseHasBody();

            // Act
            var result = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(this.News.Body, result.News.Body);
        }

        public virtual void AssignForNewsResponseHasBody()
        {
            this.News = new News { Body = "TestBody" };
            this.Dao.GetNews(this.Request.NewsId).Returns(this.News);
        }
        #endregion
    }
}
