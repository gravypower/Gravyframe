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
        public IList<Assembly> ServiceTypes { get; private set; }
        public IList<IConfigurationStrategy> ConfigurationStrategies { get; private set; }

        public EndPoint()
        {
            ServiceTypes = new List<Assembly>();
            ConfigurationStrategies = new List<IConfigurationStrategy>();

            var types = AppDomain.CurrentDomain.GetAssemblies()
               .SelectMany(s => s.GetTypes())
               .Where(t => typeof(IConfigurationStrategy).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsInterface);

            var assemblyName = new AssemblyName { Name = "Gravyframe.ServiceStack.Umbraco.Service" };
            var thisDomain = Thread.GetDomain();
            var asmBuilder = thisDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            var modBuilder = asmBuilder.DefineDynamicModule(asmBuilder.GetName().Name, false);

            foreach (var type in types)
            {
                var configurationStrategy = (IAutomaticServiceWiringConfigurationStrategy)Activator.CreateInstance(type);
                var serviceType = configurationStrategy.GetServiceType();

                var typeBuilder = modBuilder.DefineType(
                    "ServiceStack" + serviceType.Name,
                    GetTypeAttributes(),
                    serviceType,
                new[] { typeof(IService) });

                typeBuilder.CreatePassThroughConstructors(serviceType);

                ServiceTypes.Add(typeBuilder.CreateType().Assembly);
                ConfigurationStrategies.Add(configurationStrategy);
            }
        }

        public EndPoint AddEndPoint(Assembly assembly, IConfigurationStrategy configurationStrategy)
        {
            ServiceTypes.Add(assembly);
            ConfigurationStrategies.Add(configurationStrategy);
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
