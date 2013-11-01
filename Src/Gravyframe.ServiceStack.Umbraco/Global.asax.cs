using System;
using Umbraco.Web;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class Global : UmbracoApplication
    {
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            var app = new UmbracoNewsAppHost();
            app.Init();

            base.OnApplicationStarted(sender, e);
        }
    }
}