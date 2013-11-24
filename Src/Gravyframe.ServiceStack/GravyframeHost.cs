namespace Gravyframe.ServiceStack
{
    using System.Collections.Generic;
    using System.Reflection;

    using Funq;

    using global::ServiceStack.WebHost.Endpoints;

    public class GravyframeHost : AppHostBase
    {
        private readonly IEnumerable<IConfigurationStrategy> configurationStrategies;

        public GravyframeHost(IEnumerable<IConfigurationStrategy> configurationStrategies, string serviceName, params Assembly[] assembliesWithServices)
            : base(serviceName, assembliesWithServices)
        {
            this.configurationStrategies = configurationStrategies;
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public override void Configure(Container container)
        {
            foreach (var configurationStrategy in this.configurationStrategies)
            {
                configurationStrategy.ConfigureContainer(container);
                configurationStrategy.ConfigureRoutes(this.Routes);
            }
        }
    }
}
