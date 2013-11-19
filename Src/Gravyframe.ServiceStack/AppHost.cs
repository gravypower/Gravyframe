// -----------------------------------------------------------------------
// <copyright file="AppHost.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Gravyframe.ServiceStack
{
    using System.Reflection;

    using Funq;

    using global::ServiceStack.WebHost.Endpoints;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AppHost : AppHostBase
    {
        private readonly IConfigurationStrategy configurationStrategy;

        public AppHost(IConfigurationStrategy configurationStrategy, string serviceName, params Assembly[] assembliesWithServices)
            : base(serviceName, assembliesWithServices)
        {
            this.configurationStrategy = configurationStrategy;
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public override void Configure(Container container)
        {
            this.configurationStrategy.ConfigureContainer(container);
            this.configurationStrategy.ConfigureRoutes(this.Routes);
        }
    }
}
