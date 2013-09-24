using Gravyframe.Data.Content;

namespace Gravyframe.Service.Content
{
    public abstract class ContentResponseHydrator:ResponseHydrator<ContentRequest, ContentResponse>
    {
        protected readonly IContentDao ContentDao;
        protected readonly IContentConstants ContentConstants;

        protected ContentResponseHydrator(IContentDao contentDao, IContentConstants contentConstants)
        {
            ContentDao = contentDao;
            ContentConstants = contentConstants;
        }
    }
}
