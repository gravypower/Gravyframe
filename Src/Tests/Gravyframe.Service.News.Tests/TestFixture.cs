namespace Gravyframe.Service.News.Tests
{
    using System.Collections.Generic;

    using Gravyframe.Configuration;
    using Gravyframe.Data.News;
    using Gravyframe.Models;
    using Gravyframe.Service.News.Tasks;
    using Gravyframe.Service.Tests;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public abstract class TestFixture : ServiceTests<NewsRequest, NewsResponse<INews>, NewsService<INews>, NewsService<INews>.NullNewsRequestException>
    {
        public NewsDao<INews> Dao;
        public INewsConfiguration NewsConfiguration;
        public IResponseHydrogenationTaskList<NewsRequest, NewsResponse<INews>> ResponseHydrogenationTasks;

        protected override void ServiceTestsSetUp()
        {
            this.Dao = Substitute.For<NewsDao<INews>>();
            this.NewsConfiguration = Substitute.For<NewsConfiguration>();


            this.ResponseHydrogenationTasks = Substitute.For<IResponseHydrogenationTaskList<NewsRequest, NewsResponse<INews>>>();

            this.ResponseHydrogenationTasks.GetEnumerator().Returns(
               new List<ResponseHydrator<NewsRequest, NewsResponse<INews>>>
                {
                    new PopulateNewsByIdResponseHydrator<INews>(this.Dao, this.NewsConfiguration),
                    new PopulateNewsByCategoryIdResponseHydrator<INews>(this.Dao, this.NewsConfiguration)
                }.GetEnumerator());

            this.Sut = new NewsService<INews>(this.ResponseHydrogenationTasks);
        }
    }
}
