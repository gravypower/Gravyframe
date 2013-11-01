using System;
using Umbraco.Web;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class Global : UmbracoApplication
    {
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            new UmbracoNewsAppHost().Init();

            base.OnApplicationStarted(sender, e);
        }
    }
}