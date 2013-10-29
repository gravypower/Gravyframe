using Gravyframe.Constants;
using Gravyframe.Data.Content;

namespace Gravyframe.Service.Content
{
    public abstract class ContentResponseHydrator:ResponseHydrator<ContentRequest, ContentResponse>
    {
        protected readonly ContentDao<Models.Content> ContentDao;
        protected readonly IContentConstants ContentConstants;

        protected ContentResponseHydrator(ContentDao<Models.Content> contentDao, IContentConstants contentConstants)
        {
            ContentDao = contentDao;
            ContentConstants = contentConstants;
        }
    }
}
