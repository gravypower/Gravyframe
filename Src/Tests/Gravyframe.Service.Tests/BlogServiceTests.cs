using Gravyframe.Service.Blog;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class BlogServiceTests:ServiceTests<BlogRequest, BlogResponce, BlogService, BlogService.NullBlogRequestException>
    {
        protected override void ServiceSetUp()
        {
            Sut = new BlogService();
        }
    }
}
