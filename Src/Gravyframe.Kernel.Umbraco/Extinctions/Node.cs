using umbraco.interfaces;

namespace Gravyframe.Kernel.Umbraco.Extinctions
{
    public static class Node
    {
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
            
            if (handler(value, out result))
            {
                return result;
            }

            return defaultValue;
        }
    }
    public delegate bool TryParseHandler<T>(string value, out T result);
}
