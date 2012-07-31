using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SC = global::Sitecore;
using System.Web;
using Sitecore.Web;

namespace WebsiteKernel.Sitecore.Pipelines.HttpRequestEnd.Implementation
{
    public class CmsContextItemId : HttpRequestEndBase
    {
        protected override void DoProcessRequest(global::Sitecore.Pipelines.HttpRequest.HttpRequestArgs args)
        {
            //if the database in null then return
            if (SC.Context.Database == null)
                return;

            //if this is not the core database return
            if(!SC.Context.Database.Name.Equals("core", StringComparison.InvariantCultureIgnoreCase))
                return;

            //if this is not the core database return
            if(!args.LocalPath.Equals("/controls/rich text editor/preview", StringComparison.InvariantCultureIgnoreCase))
                return;

            var qs = HttpUtility.ParseQueryString(args.Url.QueryString);

            if (!qs.AllKeys.Contains("id"))
                return;

            WebUtil.SetSessionValue("CmsContextItemId", qs["id"]);


            var test = WebUtil.GetSessionValue("CmsContextItemId");
        }
    }
}
