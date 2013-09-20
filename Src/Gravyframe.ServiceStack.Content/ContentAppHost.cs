using Funq;
using Gravyframe.Data.Content;
using Gravyframe.Data.InMemory.Content;
using Gravyframe.Service.Content;
using ServiceStack.WebHost.Endpoints;

namespace Gravyframe.ServiceStack.Content
{
    public class ContentAppHost : AppHostBase 
    {
        public ContentAppHost () : base("Gravyframe Content Web Services", typeof(ContentService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            container.Register<IContentDao>(dao => new InMemoryContentDao());
            container.Register<IContentConstants>(dao => new ContentConstants());

            Routes.Add<ContentRequest>("/ContentService/{ContentId}");
            Routes.Add<ContentRequest>("/ContentService/Category/{CategoryId}");
        }
    }
}