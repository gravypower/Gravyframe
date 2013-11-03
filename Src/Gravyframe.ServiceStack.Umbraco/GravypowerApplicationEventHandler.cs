using System.Collections.Generic;
using System.Linq;
using Gravyframe.ServiceStack.Umbraco.News;
using Umbraco.Core;
using umbraco.NodeFactory;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class GravypowerApplicationEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //var sites = GetChildNodesByType(-1, "Site").Select(node => node.Name).ToList();
            new UmbracoNewsAppHost(new UmbracoNewsAppHostConfigurationStrategy()).Init();
        }

        private static IEnumerable<Node> GetChildNodesByType(int nodeId, string typeName)
        {
            return GetChildNodesByType(new Node(nodeId), typeName);
        }

        private static IEnumerable<Node> GetChildNodesByType(Node node, string typeName)
        {
            return node.Children.Cast<Node>().Where(child => child.NodeTypeAlias == typeName).ToList();
        }
    }
}