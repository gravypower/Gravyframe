using Gravyframe.Service.News;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class NewsServiceTests : ServiceTests<NewsRequest, NewsResponse, NewsService, NewsService.NullNewsRequestException>
    {
        protected override void ServiceSetUp()
        {
            Sut = new NewsService();
        }
    }
}
