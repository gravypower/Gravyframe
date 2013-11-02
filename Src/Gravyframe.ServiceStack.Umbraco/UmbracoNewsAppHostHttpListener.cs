using System.Reflection;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class UmbracoNewsAppHostHttpListener : NewsAppHostHttpListener
    {
        public UmbracoNewsAppHostHttpListener(NewsAppHostConfigurationStrategy configurationStrategy):
            base(configurationStrategy, "Gravyframe News Web Services", typeof(UmbracoNewsService).Assembly)
        {}
    }
}