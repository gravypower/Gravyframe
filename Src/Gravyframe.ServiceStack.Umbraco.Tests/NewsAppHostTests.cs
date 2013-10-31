using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco.Tests.Examine;
using NUnit.Framework;

namespace Gravyframe.ServiceStack.Umbraco.Tests
{
    [TestFixture]
    public class NewsAppHostTests
    {
        [Test]
        public void CanCreateNewsAppHost()
        {
            var mockedIndex = MockIndexFactory.GetMock(
               new MockIndexFieldList().AddIndexField("id", "Number", true),
               new MockIndexFieldList().AddIndexField(UmbracoNewsDao.CategoriesAlias),
               new[] { "News" },
               new string[] { },
               new string[] { });

            var app = new NewsAppHost();
            app.Container.Register(mockedIndex.Searcher);
            app.Init();
        }
    }
}
