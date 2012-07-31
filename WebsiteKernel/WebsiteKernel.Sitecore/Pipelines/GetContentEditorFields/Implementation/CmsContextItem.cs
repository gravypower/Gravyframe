using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Web;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.GetContentEditorFields;

namespace WebsiteKernel.Sitecore.Pipelines.GetContentEditorFields.Implementation
{
    public class CmsContextItem : GetContentEditorFieldsBase
    {
        protected override void DoProcess(GetContentEditorFieldsArgs args)
        {
            if (args.Item == null)
                return;

            WebUtil.SetSessionValue("CmsContextItem", args.Item);
        }
    }
}
