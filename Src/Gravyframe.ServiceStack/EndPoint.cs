namespace Gravyframe.ServiceStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading;

    using global::ServiceStack.ServiceHost;

    using Gravyframe.Kernel.Reflection;

    public class EndPoint
    {
        public AppHost AppHost { get; private set; }

        private readonly List<Assembly> serviceTypes;

        public IEnumerable<Assembly> ServiceTypes
        {
            get
            {
                return serviceTypes;
            }
        }

        private readonly List<IConfigurationStrategy> configurationStrategies;

        public IEnumerable<IConfigurationStrategy> ConfigurationStrategies
        {
            get
            {
                return configurationStrategies;
            }
        }

        public EndPoint()
            : this(new EndPointConfiguration())
        {
        }

        public EndPoint(EndPointConfiguration endPointConfiguration)
        {
            serviceTypes = new List<Assembly>();
            configurationStrategies = new List<IConfigurationStrategy>();

            this.configurationStrategies = new List<IConfigurationStrategy>();

            if (endPointConfiguration.AutomaticServiceWiringEnabled)
            {
                this.AutoWiring();
            }
        }

        private void AutoWiring()
        {
            var types = FindConfigurationStrategyForAutoWireing();
            var modBuilder = CreateDefineDynamicModule(CreateAssemblyBuilder());
            this.CreateAutoWireInstances(types, modBuilder);
        }

        private void CreateAutoWireInstances(IEnumerable<Type> types, ModuleBuilder modBuilder)
        {
            foreach (var type in types)
            {
                var configurationStrategy = CretaeIAutomaticServiceWiringConfigurationStrategyInstance(type);
                var serviceType = configurationStrategy.GetServiceType();

                var typeBuilder = modBuilder.DefineType(
                    "ServiceStack" + serviceType.Name,
                    GetTypeAttributes(),
                    serviceType,
                    new[] { typeof(IService) });

                typeBuilder.CreatePassThroughConstructors(serviceType);

                this.serviceTypes.Add(typeBuilder.CreateType().Assembly);
                this.configurationStrategies.Add(configurationStrategy);
            }
        }

        private static IAutomaticServiceWiringConfigurationStrategy CretaeIAutomaticServiceWiringConfigurationStrategyInstance(Type type)
        {
            return (IAutomaticServiceWiringConfigurationStrategy)Activator.CreateInstance(type);
        }

        private static ModuleBuilder CreateDefineDynamicModule(AssemblyBuilder asmBuilder)
        {
            return asmBuilder.DefineDynamicModule(asmBuilder.GetName().Name, false);
        }

        private static AssemblyBuilder CreateAssemblyBuilder()
        {
            var assemblyName = new AssemblyName { Name = "Gravyframe.ServiceStack.Umbraco.Service" };
            var thisDomain = Thread.GetDomain();
            var asmBuilder = thisDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            return asmBuilder;
        }

        private static IEnumerable<Type> FindConfigurationStrategyForAutoWireing()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(
                    t =>
                    typeof(IAutomaticServiceWiringConfigurationStrategy).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract
                    && !t.IsInterface);
        }

        public EndPoint AddEndPoint(Assembly assembly, IConfigurationStrategy configurationStrategy)
        {
            serviceTypes.Add(assembly);
            configurationStrategies.Add(configurationStrategy);
            return this;
        }

        public EndPoint Create()
        {
            AppHost = new AppHost(ConfigurationStrategies, "Gravyframe Services", ServiceTypes.ToArray());
            return this;
        }

        private static TypeAttributes GetTypeAttributes()
        {
            return TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass
                   | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout;
        }
    }
}
