using Gravyframe.Configuration;
using Gravyframe.Data.Content;

namespace Gravyframe.Service.Content
{
    public abstract class ContentResponseHydrator:ResponseHydrator<ContentRequest, ContentResponse>
    {
        protected readonly ContentDao<Models.Content> ContentDao;
        protected readonly IContentConfiguration ContentConfiguration;

        protected ContentResponseHydrator(ContentDao<Models.Content> contentDao, IContentConfiguration contentConfiguration)
        {
            ContentDao = contentDao;
            ContentConfiguration = contentConfiguration;
        }
    }
}
