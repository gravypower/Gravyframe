﻿using Funq;
using Gravyframe.Data.Content;
using Gravyframe.Data.InMemory.Content;
using Gravyframe.Service;
using Gravyframe.Service.Content;
using Gravyframe.Service.Content.Tasks;
using ServiceStack.WebHost.Endpoints;
using System.Collections.Generic;
using Gravyframe.Configuration;

namespace Gravyframe.ServiceStack.InMemory
{
    public class ContentAppHost : AppHostBase 
    {
        public ContentAppHost () : base("Gravyframe Content Web Services", typeof(ContentService).Assembly)
        {
        }

        public override void Configure(Container container)
        {

            container.Register<ContentDao<Models.Content>>(dao => new InMemoryContentDao());
            container.Register<IContentConfiguration>(constants => new ContentConfiguration());

            container.Register<IEnumerable<ResponseHydrator<ContentRequest, ContentResponse>>>(responseHydrationTasks => 
                new List<ResponseHydrator<ContentRequest, ContentResponse>>
                    {
                        new PopulateContentByCategoryIdResponseHydrator(container.Resolve<ContentDao<Models.Content>>(), container.Resolve<IContentConfiguration>()),
                        new PopulateContentByIdResponseHydrator(container.Resolve<ContentDao<Models.Content>>(), container.Resolve<IContentConfiguration>())
                    }
                );

            Routes.Add<ContentRequest>("/ContentService/");
            Routes.Add<ContentRequest>("/ContentService/{ContentId}");
            Routes.Add<ContentRequest>("/ContentService/Category/{CategoryId}");
        }
    }
}