using System;
using System.Reflection;
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

        public override void Configure(Funq.Container container)
        {
            container.Register<IContentDao>(dao => new InMemoryContentDao());
            Routes
                .Add<ContentResponse>("/ContentService/{ContentId}");
        }
    }
}