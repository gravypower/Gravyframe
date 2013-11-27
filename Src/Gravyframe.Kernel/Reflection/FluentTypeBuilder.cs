namespace Gravyframe.Kernel.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    public class FluentTypeBuilder
    {
        public Type BaseType { get; private set; }

        public Type Type { get; private set; }

        public string TypeName { get; private set; }

        public List<Type> Interfaces { get; private set; }

        public AssemblyName AssemblyName { get; private set; }

        public ModuleBuilder ModuleBuilder { get; private set; }

        public AssemblyBuilder AssemblyBuilder { get; private set; }

        private _AppDomain AppDomain { get; set; }

        public const TypeAttributes ClassTypeAttributes = 
            TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | 
            TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout;

        public const TypeAttributes InterfaceTypeAttributes = 
            TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract;

        public FluentTypeBuilder(_AppDomain appDomain)
        {

            this.AppDomain = appDomain;

            Interfaces = new List<Type>();
            BaseType = typeof(object);
            this.TypeName = "FluentTypeBuilder";
            AssemblyName = new AssemblyName { Name = "FluentTypeBuilder" };
            this.MakeBuilders();
            
        }

        public FluentTypeBuilder CreateType()
        {
            this.Type =
                ModuleBuilder.DefineType(this.TypeName, ClassTypeAttributes, this.BaseType, this.Interfaces.ToArray())
                    .CreateType();

            return this;
        }

        public object CreateInstance()
        {
            if (this.Type != null)
            {
                if (this.Type.IsInterface)
                {
                    return new FluentTypeBuilder(this.AppDomain).Implementes(this.Type).CreateInstance();
                }

                return Activator.CreateInstance(this.Type);    
            }

            return this.CreateType().CreateInstance();
        }

        public FluentTypeBuilder Implementes<T>()
        {
            return Implementes(typeof(T));
        }

        public FluentTypeBuilder Implementes(Type type)
        {
            this.Interfaces.Add(type);
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

        public FluentTypeBuilder CreateInterface()
        {
            //if (!this.TypeName.StartsWith("I"))
            //{
            //    this.TypeName = "I" + this.TypeName;
            //}

            this.Type =
                ModuleBuilder.DefineType(this.TypeName, InterfaceTypeAttributes, null, this.Interfaces.ToArray())
                    .CreateType();

            return this;
        }

        private void MakeBuilders()
        {
            this.AssemblyBuilder = this.AppDomain.DefineDynamicAssembly(this.AssemblyName, AssemblyBuilderAccess.Run);
            this.ModuleBuilder = this.AssemblyBuilder.DefineDynamicModule(this.AssemblyBuilder.GetName().Name, false);
        }
    }
}
