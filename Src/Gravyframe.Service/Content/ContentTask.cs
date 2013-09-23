using Gravyframe.Data.Content;

namespace Gravyframe.Service.Content
{
    public abstract class ContentTask:Task<ContentRequest, ContentResponse>
    {
        protected readonly IContentDao ContentDao;
        protected readonly IContentConstants ContentConstants;

        protected ContentTask(IContentDao contentDao, IContentConstants contentConstants)
        {
            ContentDao = contentDao;
            ContentConstants = contentConstants;
        }
    }
}
