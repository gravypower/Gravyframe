namespace Gravyframe.Service.Tests.News.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Gravyframe.Service.News;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public abstract class GetNewsByCategoryIdGivenNewsRequestWith : Tests
    {
        public NewsRequest Request;

        [Test]
        public void WhenNewsRequestCategoryIdAndNoNewsIdNoErrors()
        {
            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.IsFalse(response.Errors.Any());
        }

        public void WhenNewsRequestCategoryIdNewsResponseHasListOfNews(IEnumerable<Models.News> newsList)
        {
            // Assign
            var newsArray = newsList.ToArray();

            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.IsTrue(response.NewsList.Any());
            Assert.IsTrue(response.NewsList.Any(news => news == newsArray[0]));
            Assert.IsTrue(response.NewsList.Any(news => news == newsArray[1]));
        }
    }

    #region Given News Request With News Category Id

    public class GivenNewsRequestWithNewsCategoryId : GetNewsByCategoryIdGivenNewsRequestWith
    {
        [SetUp]
        public void GivenNewsRequestWithNewsCategoryIdSetUp()
        {
            this.Request = new NewsRequest { CategoryId = "SomeCategoryID" };
        }

        [Test]
        public void WhenNewsRequestCategoryIdNewsResponseHasListOfNews()
        {
            // Assign
            var newsList = new List<Models.News>
                    {
                        new Models.News {Title = "Test Body", Body = "Test Body"},
                        new Models.News {Title = "Test Body1", Body = "Test Body1"}
                    };

            this.Dao.GetNewsByCategoryId(this.Request.CategoryId).Returns(newsList);

            this.WhenNewsRequestCategoryIdNewsResponseHasListOfNews(newsList);
        }
    }
    #endregion

    #region Given News Request With News Category Id And Site Id

    public class GivenNewsRequestWithNewsCategoryIdAndSiteId : GetNewsByCategoryIdGivenNewsRequestWith
    {
        [SetUp]
        public void GivenNewsRequestWithNewsCategoryIdSetUp()
        {
            this.Request = new NewsRequest { CategoryId = "SomeCategoryID", SiteId = "TestSite"};
        }

        [Test]
        public void WhenNewsRequestCategoryIdNewsResponseHasListOfNews()
        {
            // Assign
            var newsList = new List<Models.News>
                    {
                        new Models.News {Title = "Test Body", Body = "Test Body"},
                        new Models.News {Title = "Test Body1", Body = "Test Body1"}
                    };

            this.Dao.GetNewsByCategoryId(this.Request.SiteId, this.Request.CategoryId).Returns(newsList);

            this.WhenNewsRequestCategoryIdNewsResponseHasListOfNews(newsList);
        }
    }
    #endregion
}
