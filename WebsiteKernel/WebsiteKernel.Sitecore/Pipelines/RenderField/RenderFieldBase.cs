using System;
using System.Linq;
using Sitecore.Pipelines.RenderField;

namespace WebsiteKernel.Sitecore.Pipelines.RenderField
{
    public abstract class RenderFieldBase
    {
        public void Process(RenderFieldArgs args)
        {
            WebsiteKernalNinjectKernelContainer.Inject(this);
            this.DoRenderField(args);
        }

        protected abstract void DoRenderField(RenderFieldArgs args);
    }
}
