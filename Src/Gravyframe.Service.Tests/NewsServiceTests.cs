using Gravyframe.Service.News;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class NewsServiceTests : ServiceTests<NewsResponse, NewsRequest, NewsService, NewsService.NullNewsRequestException>
    {
        protected override void BaseSetUp()
        {
            Sut = new NewsService();
        }
    }
}
