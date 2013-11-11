namespace Gravyframe.Service.Tests.NewsService
{
    using System.Collections.Generic;

    using NSubstitute;

    using NUnit.Framework;

    #region And Site Id

    public class AndSiteId_WithNewsId : WithCategoryId
    {
        [SetUp]
        public void GivenNewsRequestWithNewsCategoryIdSetUp()
        {
            this.Request.SiteId = "TestSite";
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
