using Funq;
using Gravyframe.Constants;
using Gravyframe.Data.Content;
using Gravyframe.Data.InMemory.Content;
using Gravyframe.Service;
using Gravyframe.Service.Content;
using Gravyframe.Service.Content.Tasks;
using ServiceStack.WebHost.Endpoints;
using System.Collections.Generic;

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
            container.Register<IContentConstants>(constants => new ContentConstants());

            container.Register<IEnumerable<ResponseHydrator<ContentRequest, ContentResponse>>>(responseHydratationTasks => 
                new List<ResponseHydrator<ContentRequest, ContentResponse>>
                    {
                        new PopulateContentByCategoryIdResponseHydrator(container.Resolve<IContentDao>(), container.Resolve<IContentConstants>()),
                        new PopulateContentByIdResponseHydrator(container.Resolve<IContentDao>(), container.Resolve<IContentConstants>())
                    }
                );

            Routes.Add<ContentRequest>("/ContentService/");
            Routes.Add<ContentRequest>("/ContentService/{ContentId}");
            Routes.Add<ContentRequest>("/ContentService/Category/{CategoryId}");
        }
    }
}