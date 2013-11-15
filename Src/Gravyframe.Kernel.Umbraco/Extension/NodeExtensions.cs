// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeExtensions.cs" company="Gravypowered">
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
//   Defines the NodeExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Kernel.Umbraco.Extension
{
    using umbraco.interfaces;

    /// <summary>
    /// The node extensions.
    /// </summary>
    public static class NodeExtensions
    {
        /// <summary>
        /// The try parse handler.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <typeparam name="T">
        /// the type we want to parse the <see cref="value"/> to.
        /// </typeparam>
        /// <returns>
        /// True if the pars was successful
        /// </returns>
        public delegate bool TryParseHandler<T>(string value, out T result);

        /// <summary>
        /// The get property.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <param name="handler">
        /// The handler.
        /// </param>
        /// <typeparam name="T">
        /// the type we want to parse the <see cref="propertyAlias"/> to.
        /// </typeparam>
        /// <returns>
        /// The string parse to type <see cref="T"/>.
        /// </returns>
        public static T GetProperty<T>(this INode node, string propertyAlias, T defaultValue, TryParseHandler<T> handler)
            where T : struct
        {
            if (node == null)
            {
                return defaultValue;
            }

            var value = node.GetProperty(propertyAlias).Value;

            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            
            return handler(value, out result) ? result : defaultValue;
        }

        /// <summary>
        /// The find node up tree.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="INode"/>.
        /// </returns>
        public static INode FindNodeUpTree(this INode node, string type)
        {
            while (node.Id != -1 && node.Id != 0)
            {
                if (node.Parent.NodeTypeAlias == type)
                {
                    return node.Parent;
                }

                node = node.Parent;
            }

            return null;
        }
    } 
}
