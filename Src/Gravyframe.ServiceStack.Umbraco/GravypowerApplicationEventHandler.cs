using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using umbraco.NodeFactory;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class GravypowerApplicationEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            System.Threading.Thread.Sleep(5000);

            foreach (var node  in GetChildNodesByType(-1, "Site"))
            {
                var homeNode = GetChildNodesByType(node, "Home");
                var domains = umbraco.library.GetCurrentDomains(homeNode.First().Id);
                foreach (var domain in domains)
                {
                    //domain.Name
                }
            }


        }


        private IEnumerable<Node> GetChildNodesByType(int nodeId, string typeName)
        {
            return GetChildNodesByType(new Node(nodeId), typeName);
        }

        private IEnumerable<Node> GetChildNodesByType(Node node, string typeName)
        {
            return node.Children.Cast<Node>().Where(child => child.NodeTypeAlias == typeName).ToList();
        }
    }
}