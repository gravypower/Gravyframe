namespace Gravyframe.Service.Tests.NewsService
{
    using System.Collections.Generic;
    using System.Linq;

    using Gravyframe.Service.News.Tests;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class WithCategoryId : GivenNewsRequest
    {
        [SetUp]
        public void WithCategoryId_SetUp()
        {
            this.Request.CategoryId = "SomeCategoryID";
        }

        [Test]
        public void NoNewsIdNoErrors()
        {
            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.IsFalse(response.Errors.Any());
        }

        [Test]
        public void NewsResponseHasListOfNews()
        {
            // Assign
            var newsArray = this.AssignNewsResponseHasListOfNews().ToArray();

            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.IsTrue(response.NewsList.Any());
            Assert.IsTrue(response.NewsList.Any(news => news == newsArray[0]));
            Assert.IsTrue(response.NewsList.Any(news => news == newsArray[1]));
        }

        public virtual IEnumerable<Models.News> AssignNewsResponseHasListOfNews()
        {
            // Assign
            var newsList = new List<Models.News>
                    {
                        new Models.News {Title = "Test Body", Body = "Test Body"},
                        new Models.News {Title = "Test Body1", Body = "Test Body1"}
                    };

            this.Dao.GetNewsByCategoryId(this.Request.CategoryId).Returns(newsList);

            return newsList;
        }
    }
}
