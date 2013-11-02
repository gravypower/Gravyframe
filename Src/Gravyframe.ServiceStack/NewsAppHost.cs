﻿using System.Reflection;
using Gravyframe.Service.News;
using ServiceStack.WebHost.Endpoints;

namespace Gravyframe.ServiceStack
{
    using Funq;

    public abstract class NewsAppHost : AppHostBase
    {
        private readonly NewsAppHostConfigurationStrategy _configurationStrategy;

        protected NewsAppHost(NewsAppHostConfigurationStrategy configurationStrategy, string serviceName, params Assembly[] assembliesWithServices)
            : base(serviceName, assembliesWithServices)
        {
            _configurationStrategy = configurationStrategy;
        }

        public override void Configure(Container container)
        {
            _configurationStrategy.ConfigureContainer(container);
            _configurationStrategy.ConfigureRoutes(Routes);
        }
    }
}