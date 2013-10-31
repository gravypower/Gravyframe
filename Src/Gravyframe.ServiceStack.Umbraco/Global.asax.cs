using System;
using Examine;
using Umbraco.Web;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class Global : UmbracoApplication
    {
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            var app = new NewsAppHost();
            app.Container.Register<ISearcher>(ExamineManager.Instance.SearchProviderCollection["ExternalSearcher"]);
            app.Init();

            base.OnApplicationStarted(sender, e);
        }
    }
}