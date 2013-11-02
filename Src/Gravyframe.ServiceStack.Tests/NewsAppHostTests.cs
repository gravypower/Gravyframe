using System.Linq;
using Gravyframe.Service.News;
using NUnit.Framework;
using ServiceStack.Service;
using ServiceStack.WebHost.Endpoints;

namespace Gravyframe.ServiceStack.Tests
{
    [TestFixture]
    public abstract class NewsAppHostTests<TNews>
        where TNews : Models.News
    {
        protected AppHostHttpListenerBase Sut;
        protected const string BaseUrl = "http://localhost:8024";
        protected const string ListeningOn = BaseUrl + "/";
        protected IRestClient RestClient;
        protected NewsAppHostConfigurationStrategy ConfigurationStrategy;

        [TearDown]
        public virtual void TearDown()
        {
            Sut.Dispose();
        }

        [Test]
        public void CanGetResponse()
        {
            // Act
            var result = RestClient.Get<NewsResponse<TNews>>(ConfigurationStrategy.GetNewsServiceRestPath());

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CanGetNewsItem()
        {
            // Act
            var result = RestClient.Get<NewsResponse<TNews>>(ConfigurationStrategy.GetNewsByIdNewsServiceRestPath(GetTestNewsId()));

            // Assert
            Assert.IsNotNull(result.News);
        }

        [Test]
        public void CanGetNewsItemByCategoryId()
        {
            // Act
            var result = RestClient.Get<NewsResponse<TNews>>(ConfigurationStrategy.GetNewsByCategoryIdNewsServiceRestPath(GetTestCategoryId()));

            // Assert
            Assert.IsTrue(result.NewsList.Any());
        }

        public abstract string GetTestNewsId();
        public abstract string GetTestCategoryId();
    }
}
