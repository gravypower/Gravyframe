// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GravyframeApplicationEventHandler.cs" company="Gravypowered">
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
//   Defines the GravyframeApplicationEventHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.ServiceStack.Umbraco
{
    using Gravyframe.ServiceStack.Umbraco.News;

    using global::Umbraco.Core;

    /// <summary>
    /// The gravyframe application event handler.
    /// </summary>
    public class GravyframeApplicationEventHandler : ApplicationEventHandler
    {
        /// <summary>
        /// The application started.
        /// </summary>
        /// <param name="umbracoApplication">
        /// The umbraco application.
        /// </param>
        /// <param name="applicationContext">
        /// The application context.
        /// </param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //var sites = GetChildNodesByType(-1, "Site").Select(node => node.Name).ToList();
            new UmbracoNewsAppHost(new UmbracoNewsAppHostConfigurationStrategy()).Init();
        }

        //private static IEnumerable<Node> GetChildNodesByType(int nodeId, string typeName)
        //{
        //    return GetChildNodesByType(new Node(nodeId), typeName);
        //}

        //private static IEnumerable<Node> GetChildNodesByType(Node node, string typeName)
        //{
        //    return node.Children.Cast<Node>().Where(child => child.NodeTypeAlias == typeName).ToList();
        //}
    }
}