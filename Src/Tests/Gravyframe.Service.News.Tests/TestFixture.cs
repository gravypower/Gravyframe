namespace Gravyframe.Service.News.Tests
{
    using System.Collections.Generic;

    using Gravyframe.Configuration;
    using Gravyframe.Data.News;
    using Gravyframe.Service.News.Tasks;
    using Gravyframe.Service.Tests;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public abstract class TestFixture : ServiceTests<NewsRequest, NewsResponse<Models.News>, NewsService<Models.News>, NewsService<Models.News>.NullNewsRequestException>
    {
        public NewsDao<Models.News> Dao;
        public INewsConfiguration NewsConfiguration;
        public IResponseHydrogenationTaskList<NewsRequest, NewsResponse<Models.News>> ResponseHydrogenationTasks;

        protected override void ServiceTestsSetUp()
        {
            this.Dao = Substitute.For<NewsDao<Models.News>>();
            this.NewsConfiguration = Substitute.For<NewsConfiguration>();


            this.ResponseHydrogenationTasks = Substitute.For<IResponseHydrogenationTaskList<NewsRequest, NewsResponse<Models.News>>>();

            this.ResponseHydrogenationTasks.GetEnumerator().Returns(
               new List<ResponseHydrator<NewsRequest, NewsResponse<Models.News>>>
                {
                    new PopulateNewsByIdResponseHydrator<Models.News>(this.Dao, this.NewsConfiguration),
                    new PopulateNewsByCategoryIdResponseHydrator<Models.News>(this.Dao, this.NewsConfiguration)
                }.GetEnumerator());

            this.Sut = new NewsService<Models.News>(this.ResponseHydrogenationTasks);
        }
    }
}
