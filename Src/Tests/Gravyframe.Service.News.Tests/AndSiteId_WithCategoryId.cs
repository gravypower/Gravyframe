namespace Gravyframe.Service.Tests.NewsService
{
    using System.Collections.Generic;

    using NSubstitute;

    using NUnit.Framework;

    #region And Site Id

    [TestFixture]
    public class AndSiteId_WithCategoryId : WithCategoryId
    {
        [SetUp]
        public void AndSiteId_SetUp()
        {
            this.Request.SiteId = "TestSite";
        }

        public override IEnumerable<Models.News> AssignNewsResponseHasListOfNews()
        {
            // Assign
            var newsList = new List<Models.News>
                    {
                        new Models.News {Title = "Test Body", Body = "Test Body"},
                        new Models.News {Title = "Test Body1", Body = "Test Body1"}
                    };

            this.Dao.GetNewsByCategoryId(this.Request.SiteId, this.Request.CategoryId).Returns(newsList);

            return newsList;
        }
    }
    #endregion
}
