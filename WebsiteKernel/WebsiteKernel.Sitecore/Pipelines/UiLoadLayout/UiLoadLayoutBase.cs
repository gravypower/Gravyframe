using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Pipelines.LoadLayout;

namespace WebsiteKernel.Sitecore.Pipelines.UiLoadLayout
{
    public abstract class UiLoadLayoutBase
    {
        public void Process(LoadLayoutArgs args)
        {
            WebsiteKernalNinjectKernelContainer.Inject(this);
            this.DoProcess(args);
        }

        protected abstract void DoProcess(LoadLayoutArgs args);
    }
}
