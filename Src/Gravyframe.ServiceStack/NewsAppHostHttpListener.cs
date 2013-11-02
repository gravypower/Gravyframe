using System.Reflection;
using Funq;
using ServiceStack.WebHost.Endpoints;

namespace Gravyframe.ServiceStack
{
    public class NewsAppHostHttpListener : AppHostHttpListenerBase
    {
        private readonly NewsAppHostConfigurationStrategy _configurationStrategy;

        protected NewsAppHostHttpListener(NewsAppHostConfigurationStrategy configurationStrategy, string serviceName, params Assembly[] assembliesWithServices)
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
