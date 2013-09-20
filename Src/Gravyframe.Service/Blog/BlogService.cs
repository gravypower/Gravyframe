namespace Gravyframe.Service.Blog
{
    public class BlogService : Service<BlogRequest, BlogResponce, BlogService.NullBlogRequestException>
    {
        

        public class NullBlogRequestException:NullRequestException
        {
        }

        protected override BlogResponce CreateResponce(BlogRequest request, BlogResponce responce)
        {
            return responce;
        }

        protected override BlogResponce ValidateRequest(BlogRequest request)
        {
            return new BlogResponce();
        }
    }
}
