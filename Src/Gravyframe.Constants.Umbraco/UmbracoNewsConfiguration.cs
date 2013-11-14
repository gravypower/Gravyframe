// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmbracoNewsConfiguration.cs" company="Gravypowered">
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
//   Defines the UmbracoNewsConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Configuration.Umbraco
{
    using Gravyframe.Kernel.Umbraco.Extension;
    using Gravyframe.Kernel.Umbraco.Facades;

    using umbraco.interfaces;

    /// <summary>
    /// The umbraco news configuration.
    /// </summary>
    public class UmbracoNewsConfiguration : NewsConfiguration
    {
        /// <summary>
        /// The default list size property alias.
        /// </summary>
        public const string DefaultListSizePropertyAlias = "defaultListSize";

        private int? defaultListSize;

        private readonly INodeFactoryFacade nodeFactoryFacade;

        private readonly int configurationNodeId;

        private INode configurationNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoNewsConfiguration"/> class.
        /// </summary>
        /// <param name="nodeFactoryFacade">
        /// The node factory facade.
        /// </param>
        /// <param name="configurationNodeId">
        /// The configuration node id.
        /// </param>
        public UmbracoNewsConfiguration(INodeFactoryFacade nodeFactoryFacade, int configurationNodeId)
        {
            this.nodeFactoryFacade = nodeFactoryFacade;
            this.configurationNodeId = configurationNodeId;
        }

        /// <summary>
        /// Gets the configuration node.
        /// </summary>
        public INode ConfigurationNode
        {
            get
            {
                if (this.configurationNode == null)
                {
                    this.configurationNode = this.nodeFactoryFacade.GetNode(this.configurationNodeId);
                }

                return this.configurationNode;
            }
        }

        /// <summary>
        /// Gets the default list size.
        /// </summary>
        public override int DefaultListSize
        {
            get
            {
                if (!this.defaultListSize.HasValue)
                {
                    this.defaultListSize = this.ConfigurationNode.GetProperty(DefaultListSizePropertyAlias, base.DefaultListSize, int.TryParse);
                }

                return this.defaultListSize.Value;
            }
        }
    }
}
