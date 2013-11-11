namespace Gravyframe.Service.Tests.NewsService
{
    using Gravyframe.Service.News;

    using NUnit.Framework;

    [TestFixture]
    public abstract class GivenNewsRequest : TestFixture
    {
        #region Given News Request

        public NewsRequest Request;
        public Models.News News;

        #endregion
    }
}
