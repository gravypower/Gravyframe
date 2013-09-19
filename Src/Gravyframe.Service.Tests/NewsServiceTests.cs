using Gravyframe.Service.News;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class NewsServiceTests
    {
        public NewsService Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = new NewsService();
        }

        [Test]
        public void CanCreateNEwsService()
        {
            // Assert
            Assert.IsNotNull(Sut);
        }

        [Test]
        public void WhenNewsRequestIsNullNewsRequestThrown()
        {
            // Assert
            Assert.Throws<NewsService.NullNewsRequestException>(() => Sut.Get(null));
        }

        [Test]
        public void WhenNewsRequestInNotNullNullNewsRequestExceptionNotThrown()
        {
            // Assign
            var request = new NewsRequest();

            // Assert
            Assert.DoesNotThrow(() => Sut.Get(request));
        }

        [Test]
        public void WhenNewsRequestIsNotNullNewsResponceNotNull()
        {
            // Assign
            var request = new NewsRequest();

            // Act
            var responce = Sut.Get(request);

            // Assert
            Assert.IsNotNull(responce);
        }

    }
}
