using System.Reflection;
using ServiceStack.WebHost.Endpoints;
using Funq;

namespace Gravyframe.ServiceStack
{
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
