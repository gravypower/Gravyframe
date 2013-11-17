namespace Gravyframe.Service.News.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public abstract class GivenNewsRequest : TestFixture
    {
        #region Given News Request
        public NewsRequest Request;

        [SetUp]
        public void GivenNewsRequest_SetUp()
        {
            this.Request = new NewsRequest();
        }

        #endregion
    }
}
