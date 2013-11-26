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

        public Type Type { get; private set; }

        public string TypeName { get; private set; }

        public List<Type> Interfaces { get; private set; }

        public AssemblyName AssemblyName { get; private set; }

        public ModuleBuilder ModuleBuilder { get; private set; }

        public AssemblyBuilder AssemblyBuilder { get; private set; }

        public TypeAttributes TypeAttributes { get; private set; }

        public FluentTypeBuilder()
        {
            Interfaces = new List<Type>();
            BaseType = typeof(object);
            this.TypeName = "FluentTypeBuilder";
            AssemblyName = new AssemblyName { Name = "FluentTypeBuilder" };
            this.MakeBuilders();
            TypeAttributes = TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass
                             | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout;
        }

        private void MakeBuilders()
        {
            this.AssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(this.AssemblyName, AssemblyBuilderAccess.Run);
            this.ModuleBuilder = this.AssemblyBuilder.DefineDynamicModule(this.AssemblyBuilder.GetName().Name, false);
        }

        public FluentTypeBuilder CreateType()
        {
            this.Type = ModuleBuilder.DefineType(
               this.TypeName,
               this.TypeAttributes,
               this.BaseType,
               this.Interfaces.ToArray()).CreateType();

            return this;
        }

        public object CreateInstance()
        {
            if (this.Type != null)
            {
                return Activator.CreateInstance(this.Type);    
            }

            return this.CreateType().CreateInstance();
        }

        public FluentTypeBuilder Implementes<T>()
        {
            this.Interfaces.Add(typeof(T));
            return this;
        }

        public FluentTypeBuilder BaseTypeOf<T>()
        {
            return BaseTypeOf(typeof(T));
        }

        public FluentTypeBuilder BaseTypeOf(Type type)
        {
            this.BaseType = type;
            return this;
        }

        public FluentTypeBuilder SetAssemblyName(string assemblyName)
        {
            this.AssemblyName.Name = assemblyName;
            this.MakeBuilders();
            return this;
        }

        public FluentTypeBuilder SetTypeName(string name)
        {
            this.TypeName = name;
            return this;
        }   
    }
}
