using umbraco.interfaces;

namespace Gravyframe.Kernel.Umbraco.Extension
{
    public static class NodeExtensions
    {
        public delegate bool TryParseHandler<T>(string value, out T result);
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

        public static INode FindNodeUpTree(this INode node, string type)
        {
            while (node.Id != -1 && node.Id != 0 )
            {
                if (node.Parent.NodeTypeAlias == type)
                    return node.Parent;

                node = node.Parent;
            }

            return null;
        }
    }
    
}
