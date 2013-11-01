using System.Reflection;
using ServiceStack.WebHost.Endpoints;

namespace Gravyframe.ServiceStack
{
    using Funq;

    public abstract class NewsAppHost : AppHostHttpListenerBase
    {
        protected NewsAppHost(string serviceName, params Assembly[] assembliesWithServices):base(serviceName, assembliesWithServices)
        {
        }

        public override void Configure(Container container)
        {
            this.RegisterExternalDependencies();
            this.RegisterDependencies();
        }

        protected abstract void RegisterDependencies();
        protected abstract void RegisterExternalDependencies();
    }
}
