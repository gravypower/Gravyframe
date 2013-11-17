namespace Gravyframe.Service.News.Tests
{
    using System.Linq;

    using Gravyframe.Service.Messages;

    using NUnit.Framework;

    #region Given News Request With No News Id

    [TestFixture]
    public class WithNoNewsId : GivenNewsRequest
    {
        [SetUp]
        public void WithNoNewsId_SetUp()
        {
        }

        [Test]
        public void WhenNewsRequestNoNewsIdNewsResponseFailure()
        {
            // Act
            var response = this.Sut.Get(this.Request);

            // Assert
            Assert.AreEqual(ResponseCodes.Failure, response.Code);
            Assert.AreEqual(ResponseCodes.Failure, response.Code);
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
