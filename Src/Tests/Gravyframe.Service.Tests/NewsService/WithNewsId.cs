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
        public void WithNewsId_SetUp()
        {
            this.Request.NewsId = "SomeID";
        }

        [Test]
        public void NewsResponseSuccess()
        {
            // Assign 
            this.AssignNewsResponseSuccess();

            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponseCodes.Success, response.Code);
        }
        
        public virtual News AssignNewsResponseSuccess()
        {
            var news = new News();
            this.Dao.GetNews(this.Request.NewsId).Returns(news);

            return news;
        }

        [Test]
        public void NewsInResponseFailure()
        {
            this.AssignNewsInResponseFailure();

            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponseCodes.Failure, response.Code);
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
            var news = this.AssignForNewsResponseHasTitle();
            // Act
            var result = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(news.Title, result.News.Title);
        }

        public virtual News AssignForNewsResponseHasTitle()
        {
            var news = new News { Title = "TestTitle" };
            this.Dao.GetNews(this.Request.NewsId).Returns(news);
            return news;
        }

        [Test]
        public void NewsResponseHasBody()
        {
            // Assign
            var news = this.AssignForNewsResponseHasBody();

            // Act
            var result = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(news.Body, result.News.Body);
        }

        public virtual News AssignForNewsResponseHasBody()
        {
            var news = new News { Body = "TestBody" };
            this.Dao.GetNews(this.Request.NewsId).Returns(news);
            return news;
        }
        #endregion
    }
}
