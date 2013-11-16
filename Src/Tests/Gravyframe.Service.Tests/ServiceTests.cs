using Gravyframe.Service.Messages;
using NUnit.Framework;
namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public abstract class ServiceTests<TRequest, TResponse, TService, TNullRequestException>
        where TResponse : Response, new()
        where TRequest : Request, new()
        where TService : Service<TRequest, TResponse, TNullRequestException>
        where TNullRequestException : Service<TRequest, TResponse, TNullRequestException>.NullRequestException, new()

    {
        public TService Sut;

        [SetUp]
        protected void SetUp()
        {
            this.ServiceTestsSetUp();
        }

        protected abstract void ServiceTestsSetUp();

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
            Assert.IsInstanceOf<Service<TRequest, TResponse, TNullRequestException>>(Sut);
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
            var response = Sut.Get(request);

            // Assert
            Assert.IsNotNull(response);
        }
    }
}
