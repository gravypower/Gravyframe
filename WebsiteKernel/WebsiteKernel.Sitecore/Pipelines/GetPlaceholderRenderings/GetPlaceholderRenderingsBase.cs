using System;
using System.Linq;
using Sitecore.Pipelines.GetPlaceholderRenderings;

namespace WebsiteKernel.Sitecore.Pipelines.GetPlaceholderRenderings
{
    public abstract class GetPlaceholderRenderingsBase : GetAllowedRenderings
    {
        public new void Process(GetPlaceholderRenderingsArgs args)
        {
            WebsiteKernalNinjectKernelContainer.Inject(this);
            this.DoGetAllowedRenderingsa(args);
        }

        protected abstract void DoGetAllowedRenderingsa(GetPlaceholderRenderingsArgs args);
    }
}
