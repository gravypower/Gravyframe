namespace Gravyframe.ServiceStack.Umbraco.News
{
    public class UmbracoNewsAppHostHttpListener : NewsAppHostHttpListener
    {
        public UmbracoNewsAppHostHttpListener(NewsAppHostConfigurationStrategy configurationStrategy):
            base(configurationStrategy, "Gravyframe News Web Services", typeof(UmbracoNewsService).Assembly)
        {}
    }
}