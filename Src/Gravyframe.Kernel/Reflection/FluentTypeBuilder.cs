namespace Gravyframe.Kernel.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading;

    public class FluentTypeBuilder
    {
        public Type BaseType { get; private set; }

        public List<Type> Interfaces { get; private set; }

        public AssemblyName AssemblyName { get; private set; }

        public ModuleBuilder ModuleBuilder { get; private set; }

        public AssemblyBuilder AssemblyBuilder { get; private set; }

        public TypeAttributes TypeAttributes { get; private set; }

        public FluentTypeBuilder()
        {
            Interfaces = new List<Type>();
            BaseType = typeof(object);
            AssemblyName = new AssemblyName { Name = "FluentTypeBuilder" };
            AssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(AssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder = AssemblyBuilder.DefineDynamicModule(AssemblyBuilder.GetName().Name, false);

            TypeAttributes = TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass
                             | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout;
        }

        public object CreateType()
        {

            ModuleBuilder.DefineType(
               "FluentTypeBuilder",
               TypeAttributes,
               BaseType,
               Interfaces.ToArray()).CreateType();
            return new object();
        }

        public FluentTypeBuilder Implementes<T>()
        {
            Interfaces.Add(typeof(T));
            return this;
        }

        public FluentTypeBuilder BaseTypeOf<T>()
        {
            BaseType = typeof(T);
            return this;
        }
    }
}
