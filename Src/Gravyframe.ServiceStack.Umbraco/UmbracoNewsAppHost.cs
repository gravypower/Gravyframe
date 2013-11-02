namespace Gravyframe.ServiceStack.Umbraco
{
    public class UmbracoNewsAppHost : NewsAppHost 
    {
        public UmbracoNewsAppHost(NewsAppHostConfigurationStrategy configurationStrategy)
            : base(configurationStrategy, "Gravyframe News Web Services", typeof(UmbracoNewsService).Assembly)
        {
        }
    }
}