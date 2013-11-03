using System.Collections.Generic;
using System.Linq;
using Gravyframe.Service.News;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Service.Tests.News
{
    [TestFixture]
    public abstract class GetNewsByCategoryIdGivenNewsRequestWith : NewsServiceTests
    {
        public NewsRequest Request;

        [Test]
        public void WhenNewsRequestCategoryIdAndNoNewsIdNoErrors()
        {
            // Act
            var response = Sut.Get(Request);

            // Assert
            Assert.IsFalse(response.Errors.Any());
        }

        public void WhenNewsRequestCategoryIdNewsResponseHasListOfNews(IEnumerable<Models.News> newsList)
        {
            // Assign
            var newsArray = newsList.ToArray();

            // Act
            var response = Sut.Get(Request);

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
            Request = new NewsRequest { CategoryId = "SomeCategoryID" };
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

            Dao.GetNewsByCategoryId(Request.CategoryId).Returns(newsList);

            WhenNewsRequestCategoryIdNewsResponseHasListOfNews(newsList);
        }
    }
    #endregion

    #region Given News Request With News Category Id And Site Id

    public class GivenNewsRequestWithNewsCategoryIdAndSiteId : GetNewsByCategoryIdGivenNewsRequestWith
    {
        [SetUp]
        public void GivenNewsRequestWithNewsCategoryIdSetUp()
        {
            Request = new NewsRequest { CategoryId = "SomeCategoryID", SiteId = "TestSite"};
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

            Dao.GetNewsByCategoryId(Request.SiteId, Request.CategoryId).Returns(newsList);

            WhenNewsRequestCategoryIdNewsResponseHasListOfNews(newsList);
        }
    }
    #endregion
}
