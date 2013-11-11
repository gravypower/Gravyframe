namespace Gravyframe.Service.Tests.NewsService
{
    using NSubstitute;
    using NUnit.Framework;

    public class AndSiteId : WithNewsId
    {
        #region And Site ID
        [SetUp]
        public void AndSiteIdSetUp()
        {
            this.Request.SiteId = "TestSite";
        }

        public override void AssignNewsResponseSuccess()
        {
            base.AssignNewsResponseSuccess();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(this.News);
        }

        public override void AssignForNewsResponseHasTitle()
        {
            base.AssignForNewsResponseHasTitle();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(this.News);
        }

        public override void AssignForNewsResponseHasBody()
        {
            base.AssignForNewsResponseHasBody();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(this.News);
        }
        #endregion
    }
    
}
