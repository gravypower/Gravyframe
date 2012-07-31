using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.GetContentEditorFields;

namespace WebsiteKernel.Sitecore.Pipelines.GetContentEditorFields
{
    public abstract class GetContentEditorFieldsBase
    {
        public void Process(GetContentEditorFieldsArgs args)
        {
            WebsiteKernalNinjectKernelContainer.Inject(this);
            this.DoProcess(args);
        }

        protected abstract void DoProcess(GetContentEditorFieldsArgs args);
    }
}
