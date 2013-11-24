namespace Gravyframe.ServiceStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading;

    using Gravyframe.Kernel.Reflection;

    using global::ServiceStack.ServiceHost;

    public class EndPoint
    {
        public EndPoint()
            : this(new EndPointConfiguration())
        {
        }

        public EndPoint(EndPointConfiguration endPointConfiguration)
        {
            this.serviceTypes = new List<Assembly>();
            this.configurationStrategies = new List<IConfigurationStrategy>();

            this.configurationStrategies = new List<IConfigurationStrategy>();

            if (endPointConfiguration.AutomaticServiceWiringEnabled)
            {
                this.AutoWiring();
            }
        }

        public IEnumerable<Assembly> ServiceTypes
        {
            get
            {
                return this.serviceTypes;
            }
        }

        public IEnumerable<IConfigurationStrategy> ConfigurationStrategies
        {
            get
            {
                return this.configurationStrategies;
            }
        }

        public GravyframeHost GravyframeHost { get; private set; }

        private void AutoWiring()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(
                    t =>
                    typeof(IAutomaticServiceHostingConfigurationStrategy).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract
                    && !t.IsInterface);
            var assemblyName = new AssemblyName { Name = "Gravyframe.ServiceStack.Umbraco.Service" };
            var asmBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            var modBuilder = asmBuilder.DefineDynamicModule(asmBuilder.GetName().Name, false);
            foreach (var type in types)
            {
                var configurationStrategy = (IAutomaticServiceHostingConfigurationStrategy)Activator.CreateInstance(type);
                var serviceType = configurationStrategy.GetServiceType();

                var typeBuilder = modBuilder.DefineType(
                    "ServiceStack" + serviceType.Name,
                    TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass
                    | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout,
                    serviceType,
                    new[] { typeof(IService) });

                typeBuilder.CreatePassThroughConstructors(serviceType);

                this.serviceTypes.Add(typeBuilder.CreateType().Assembly);
                this.configurationStrategies.Add(configurationStrategy);
            }
        }

        private readonly List<Assembly> serviceTypes;

        private readonly List<IConfigurationStrategy> configurationStrategies;

        public EndPoint AddEndPoint(Assembly assembly, IConfigurationStrategy configurationStrategy)
        {
            serviceTypes.Add(assembly);
            configurationStrategies.Add(configurationStrategy);
            return this;
        }

        public EndPoint Create()
        {
            this.GravyframeHost = new GravyframeHost(ConfigurationStrategies, "Gravyframe Services", ServiceTypes.ToArray());
            return this;
        }
    }
}
