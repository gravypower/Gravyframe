using umbraco.interfaces;

namespace Gravyframe.Constants.Umbraco
{
    /// <summary>
    /// 
    /// </summary>
    public class UmbracoNewsConstants : INewsConstants
    {
        public string NewsIdError { get; private set; }
        public string NewsCategoryIdError { get; private set; }
        public int DefaultListSize { get; private set; }

        public UmbracoNewsConstants(INode node)
        {
            var defaultListSize = 0;
            if (!int.TryParse(node.GetProperty("DefaultListSize").Value, out defaultListSize))
            {
                var newsConstants = new NewsConstants();
                DefaultListSize = newsConstants.DefaultListSize;
            }
            else
            {
                DefaultListSize = defaultListSize;
            }
        }
    }
}
