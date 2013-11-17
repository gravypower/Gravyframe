namespace Gravyframe.Service.Tests.NewsService
{
    using NSubstitute;
    using NUnit.Framework;

    public class AndSiteId_WithNewsId : WithNewsId
    {
        #region And Site ID
        [SetUp]
        public void AndSiteId_SetUp()
        {
            this.Request.SiteId = "TestSite";
        }

        public override Models.News AssignNewsResponseSuccess()
        {
            var news = base.AssignNewsResponseSuccess();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);
            return news;
        }

        public override Models.News AssignForNewsResponseHasTitle()
        {
            var news = base.AssignForNewsResponseHasTitle();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);
            return news;
        }

        public override Models.News AssignForNewsResponseHasBody()
        {
            var news = base.AssignForNewsResponseHasBody();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);
            return news;
        }
        #endregion
    }
    
}
