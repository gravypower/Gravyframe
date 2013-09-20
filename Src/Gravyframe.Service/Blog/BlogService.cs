namespace Gravyframe.Service.Blog
{
    public class BlogService:Service<BlogRequest, BlogResponce>
    {
        public override BlogResponce Get(BlogRequest request)
        {
            if (request == null)
                throw new NullBlogRequestException();

            return new BlogResponce();
        }

        
        public class NullBlogRequestException:NullRequestException
        {
        }
    }
}
