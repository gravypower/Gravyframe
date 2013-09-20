using Gravyframe.Service.Messages;
using NUnit.Framework;
namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public abstract class ServiceTests<TRequest, TResponce, TService, TNullRequestException>
        where TResponce : Response, new()
        where TRequest : Request, new() 
        where TService : Service<TRequest, TResponce>
        where TNullRequestException : Service<TRequest,TResponce>.NullRequestException

    {
        public TService Sut;

        [SetUp]
        public void SetUp()
        {
            ServiceSetUp();
        }

        protected abstract void ServiceSetUp();

        [Test]
        public void CanCreateTService()
        {
            // Assert
            Assert.IsNotNull(Sut);
        }

        [Test]
        public void IsAssignableFromTService()
        {
            // Assert 
            Assert.IsInstanceOf<Service<TRequest, TResponce>>(Sut);
        }

        [Test]
        public void WhenRequestIsNullTNullRequestThrown()
        {
            // Assert
            Assert.Throws<TNullRequestException>(() => Sut.Get(null));
        }

        [Test]
        public void WhenTRequestInNotNullTNullRequestExceptionNotThrown()
        {
            // Assign
            var request = new TRequest();

            // Assert
            Assert.DoesNotThrow(() => Sut.Get(request));
        }

        [Test]
        public void WhenTRequestIsNotNullTResponceNotNull()
        {
            // Assign
            var request = new TRequest();

            // Act
            var responce = Sut.Get(request);

            // Assert
            Assert.IsNotNull(responce);
        }
    }
}
