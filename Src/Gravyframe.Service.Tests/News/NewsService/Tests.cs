namespace Gravyframe.Service.Tests.News.NewsService
{
    using System.Collections.Generic;
    using System.Linq;

    using Gravyframe.Configuration;
    using Gravyframe.Data.News;
    using Gravyframe.Service.Messages;
    using Gravyframe.Service.News;
    using Gravyframe.Service.News.Tasks;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class Tests : ServiceTests<NewsRequest, NewsResponse<Models.News>, NewsService<Models.News>, NewsService<Models.News>.NullNewsRequestException>
    {
        public NewsDao<Models.News> Dao;
        public INewsConfiguration NewsConfiguration;
        public IResponseHydrogenationTaskList<NewsRequest, NewsResponse<Models.News>> ResponseHydrogenationTasks;

        [SetUp]
        protected override void ServiceSetUp()
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

        #region Given News Request With No News Id

        [TestFixture]
        public class GivenNewsRequestWithNoNewsId : Tests
        {
            public NewsRequest Request;

            [SetUp]
            public void GivenNewsRequestWithNoNewsIdSetUp()
            {
                this.Request = new NewsRequest();
            }

            [Test]
            public void WhenNewsRequestNoNewsIdNewsResponseFailure()
            {
                // Act
                var response = this.Sut.Get(this.Request);

                // Assert
                Assert.AreEqual(ResponceCodes.Failure, response.Code);
                Assert.AreEqual(ResponceCodes.Failure, response.Code);
            }

            [Test]
            public void WhenNewsRequestNoNewsIdNewsResponseErrors()
            {
                // Act
                var response = this.Sut.Get(this.Request);

                // Assert
                Assert.IsTrue(response.Errors.Any());
                Assert.IsTrue(response.Errors.Any(error => error == this.NewsConfiguration.NullNewsError));
            }
        }
        #endregion
    }
}
