namespace Gravyframe.Data.Sitefinity.Tests.SitefinityNewsDao
{
    using Gravyframe.Data.News;
    using Gravyframe.Data.Tests.NewsDao;
    using Gravyframe.Models.Sitefinity;

    
    using Telerik.Sitefinity.Modules.News;

    public class TestContext : INewsDaoTestContext<SitefinityNews>
    {
        public const int NewsConfigurationNodeId = 1000;
        public const string IndexType = "News";
        public const string TestCategoryId = "TestCategoryId";
        
        public NewsDataProvider NewsDataProvider;

        public TestContext()
        {
            var t = new test();
            //this.NewsDataProvider = Substitute.For<NewsDataProvider>();
            Sut = new News.SitefinityNewsDao(NewsDataProvider);
        }

        public NewsDao<SitefinityNews> Sut { get; private set; }

        public string ExampleCategoryId
        {
            get
            {
                return TestCategoryId;
            }
        }

        public string ExampleId
        {
            get
            {
                return "2";
            }
        }

        public string ExampleSiteId
        {
            get
            {
                return TestCategoryId;
            }
        }
    }

    public class test : NewsDataProvider
    {

        public override Telerik.Sitefinity.Lifecycle.LanguageData CreateLanguageData(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public override Telerik.Sitefinity.Lifecycle.LanguageData CreateLanguageData()
        {
            throw new System.NotImplementedException();
        }

        public override Telerik.Sitefinity.News.Model.NewsItem CreateNewsItem(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public override Telerik.Sitefinity.News.Model.NewsItem CreateNewsItem()
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(Telerik.Sitefinity.News.Model.NewsItem newsItemToDelete)
        {
            throw new System.NotImplementedException();
        }

        public override System.Linq.IQueryable<Telerik.Sitefinity.Lifecycle.LanguageData> GetLanguageData()
        {
            throw new System.NotImplementedException();
        }

        public override Telerik.Sitefinity.Lifecycle.LanguageData GetLanguageData(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public override Telerik.Sitefinity.News.Model.NewsItem GetNewsItem(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public override System.Linq.IQueryable<Telerik.Sitefinity.News.Model.NewsItem> GetNewsItems()
        {
            throw new System.NotImplementedException();
        }
    }
}
