using System;
using Gravyframe.ServiceStack.Umbraco.News;
using Umbraco.Web;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class Global : UmbracoApplication
    {
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);

            //new UmbracoNewsAppHost(new UmbracoNewsAppHostConfigurationStrategy()).Init();
        }
    }
}