using System.Collections.Generic;
using System.Linq;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Service.Messages;
using Gravyframe.Service.News;
using Gravyframe.Service.News.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Service.Tests.News
{
    [TestFixture]
    public class NewsServiceTests : ServiceTests<NewsRequest, NewsResponse<Models.News>, NewsService<Models.News>, NewsService<Models.News>.NullNewsRequestException>
    {
        public NewsDao<Models.News> Dao;
        public INewsConfiguration NewsConfiguration;
        public IResponseHydrogenationTaskList<NewsRequest, NewsResponse<Models.News>> ResponseHydrogenationTasks;

        [SetUp]
        protected override void ServiceSetUp()
        {
            Dao = Substitute.For<NewsDao<Models.News>>();
            NewsConfiguration = Substitute.For<NewsConfiguration>();


            ResponseHydrogenationTasks = Substitute.For<IResponseHydrogenationTaskList<NewsRequest, NewsResponse<Models.News>>>();

            ResponseHydrogenationTasks.GetEnumerator().Returns(
               new List<ResponseHydrator<NewsRequest, NewsResponse<Models.News>>>
                {
                    new PopulateNewsByIdResponseHydrator<Models.News>(Dao, NewsConfiguration),
                    new PopulateNewsByCategoryIdResponseHydrator<Models.News>(Dao, NewsConfiguration)
                }.GetEnumerator());

            Sut = new NewsService<Models.News>(ResponseHydrogenationTasks);
        }

        #region Given News Request With No News Id

        [TestFixture]
        public class GivenNewsRequestWithNoNewsId : NewsServiceTests
        {
            public NewsRequest Request;

            [SetUp]
            public void GivenNewsRequestWithNoNewsIdSetUp()
            {
                Request = new NewsRequest();
            }

            [Test]
            public void WhenNewsRequestNoNewsIdNewsResponseFailure()
            {
                // Act
                var response = Sut.Get(Request);

                // Assert
                Assert.AreEqual(ResponceCodes.Failure, response.Code);
                Assert.AreEqual(ResponceCodes.Failure, response.Code);
            }

            [Test]
            public void WhenNewsRequestNoNewsIdNewsResponseErrors()
            {
                // Act
                var response = Sut.Get(Request);

                // Assert
                Assert.IsTrue(response.Errors.Any());
                Assert.IsTrue(response.Errors.Any(error => error == NewsConfiguration.NullNewsError));
            }
        }
        #endregion
    }
}
