// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentTypeBuilder.cs" company="Gravypowered">
//   Copyright 2013 Aaron Job
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Defines the FluentTypeBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Kernel.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    /// <summary>
    /// The fluent type builder.
    /// </summary>
    public class FluentTypeBuilder
    {
        /// <summary>
        /// The interface type attributes.
        /// </summary>
        public const TypeAttributes InterfaceTypeAttributes = 
            TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract;

        /// <summary>
        /// The class type attributes.
        /// </summary>
        public const TypeAttributes ClassTypeAttributes = 
            TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | 
            TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentTypeBuilder"/> class.
        /// </summary>
        /// <param name="appDomain">
        /// The app domain.
        /// </param>
        public FluentTypeBuilder(_AppDomain appDomain)
        {
            this.AppDomain = appDomain;

            this.Interfaces = new List<Type>();
            this.BaseType = typeof(object);
            this.TypeName = "FluentTypeBuilder";
            this.AssemblyName = new AssemblyName { Name = "FluentTypeBuilder" };
            this.MakeBuilders();
        }

        /// <summary>
        /// Gets the base type.
        /// </summary>
        /// <value>
        /// The base type.
        /// </value>
        public Type BaseType { get; private set; }

        /// <summary>
        /// Gets the type that is being build.
        /// </summary>
        /// <value>
        /// The type that has been build.
        /// </value>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the type name.
        /// </summary>
        /// <value>
        /// The type name.
        /// </value>
        public string TypeName { get; private set; }

        /// <summary>
        /// Gets the interfaces.
        /// </summary>
        /// <value>
        /// The interfaces.
        /// </value>
        public List<Type> Interfaces { get; private set; }

        /// <summary>
        /// Gets the assembly name.
        /// </summary>
        /// <value>
        /// The assembly name.
        /// </value>
        public AssemblyName AssemblyName { get; private set; }

        /// <summary>
        /// Gets the module builder.
        /// </summary>
        /// <value>
        /// The module builder.
        /// </value>
        public ModuleBuilder ModuleBuilder { get; private set; }

        /// <summary>
        /// Gets the type builder.
        /// </summary>
        /// <value>
        /// The type builder.
        /// </value>
        public TypeBuilder TypeBuilder { get; private set; }

        /// <summary>
        /// Gets the assembly builder.
        /// </summary>
        /// <value>
        /// The assembly builder.
        /// </value>
        public AssemblyBuilder AssemblyBuilder { get; private set; }

        private _AppDomain AppDomain { get; set; }

        /// <summary>
        /// The create type.
        /// </summary>
        /// <returns>
        /// The <see cref="FluentTypeBuilder"/>.
        /// </returns>
        public FluentTypeBuilder CreateType()
        {
            this.TypeBuilder = ModuleBuilder.DefineType(
                this.TypeName,
                ClassTypeAttributes,
                this.BaseType,
                this.Interfaces.ToArray());

            this.TypeBuilder.CreatePassThroughConstructors(this.BaseType);

            this.Type = TypeBuilder.CreateType();

            return this;
        }

        /// <summary>
        /// The create instance.
        /// </summary>
        /// <param name="constructorArguments">
        /// The arguments for the constructor.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object CreateInstance(object[] constructorArguments = null)
        {
            if (this.Type == null)
            {
                return this.CreateType().CreateInstance();
            }

            if (this.Type.IsInterface)
            {
                return new FluentTypeBuilder(this.AppDomain).Implements(this.Type).CreateInstance();
            }

            return Activator.CreateInstance(this.Type, constructorArguments);
        }

        /// <summary>
        /// The implements.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the interface.
        /// </typeparam>
        /// <returns>
        /// The <see cref="FluentTypeBuilder"/>.
        /// </returns>
        public FluentTypeBuilder Implements<T>()
        {
            return this.Implements(typeof(T));
        }

        /// <summary>
        /// The implements.
        /// </summary>
        /// <param name="type">
        /// The type of the interface.
        /// </param>
        /// <returns>
        /// The <see cref="FluentTypeBuilder"/>.
        /// </returns>
        public FluentTypeBuilder Implements(Type type)
        {
            this.Interfaces.Add(type);
            return this;
        }

        /// <summary>
        /// The base type of.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the interface.
        /// </typeparam>
        /// <returns>
        /// The <see cref="FluentTypeBuilder"/>.
        /// </returns>
        public FluentTypeBuilder BaseTypeOf<T>()
        {
            return this.BaseTypeOf(typeof(T));
        }

        /// <summary>
        /// The base type of.
        /// </summary>
        /// <param name="type">
        /// The type that the new type will be based off.
        /// </param>
        /// <returns>
        /// The <see cref="FluentTypeBuilder"/>.
        /// </returns>
        public FluentTypeBuilder BaseTypeOf(Type type)
        {
            this.BaseType = type;
            return this;
        }

        /// <summary>
        /// The set assembly name.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <returns>
        /// The <see cref="FluentTypeBuilder"/>.
        /// </returns>
        public FluentTypeBuilder SetAssemblyName(string assemblyName)
        {
            this.AssemblyName.Name = assemblyName;
            this.MakeBuilders();
            return this;
        }

        /// <summary>
        /// The set type name.
        /// </summary>
        /// <param name="name">
        /// The name of the type we are building.
        /// </param>
        /// <returns>
        /// The <see cref="FluentTypeBuilder"/>.
        /// </returns>
        public FluentTypeBuilder SetTypeName(string name)
        {
            this.TypeName = name;
            return this;
        }

        /// <summary>
        /// The create interface.
        /// </summary>
        /// <returns>
        /// The <see cref="FluentTypeBuilder"/>.
        /// </returns>
        public FluentTypeBuilder CreateInterface()
        {
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
