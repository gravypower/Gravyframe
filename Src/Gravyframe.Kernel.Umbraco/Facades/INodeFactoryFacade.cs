// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INodeFactoryFacade.cs" company="Gravypowered">
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
//   Defines the INodeFactoryFacade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Kernel.Umbraco.Facades
{
    using umbraco.interfaces;

    /// <summary>
    /// The NodeFactoryFacade interface.
    /// </summary>
    public interface INodeFactoryFacade
    {
        /// <summary>
        /// The get node.
        /// </summary>
        /// <param name="nodeId">
        /// The node id.
        /// </param>
        /// <returns>
        /// The <see cref="INode"/>.
        /// </returns>
        INode GetNode(int nodeId);
    }
}
