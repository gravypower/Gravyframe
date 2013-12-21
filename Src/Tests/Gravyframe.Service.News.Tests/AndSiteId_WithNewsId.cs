namespace Gravyframe.Service.Tests.NewsService
{
    using Gravyframe.Models;

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

        public override News AssignNewsResponseSuccess()
        {
            var news = base.AssignNewsResponseSuccess();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);
            return news;
        }

        public override News AssignForNewsResponseHasTitle()
        {
            var news = base.AssignForNewsResponseHasTitle();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);
            return news;
        }

        public override News AssignForNewsResponseHasBody()
        {
            var news = base.AssignForNewsResponseHasBody();
            this.Dao.GetNews(this.Request.SiteId, this.Request.NewsId).Returns(news);
            return news;
        }

        public override void AssignNewsInResponseFailure()
        {
            this.Dao.GetNews(this.Request.SiteId,this.Request.NewsId).Returns(default(INews));
        }

        #endregion
    }
    
}
