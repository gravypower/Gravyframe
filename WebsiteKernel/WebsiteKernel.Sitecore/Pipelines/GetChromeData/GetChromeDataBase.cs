using System;
using System.Linq;
using Sitecore.Pipelines.GetChromeData;

namespace WebsiteKernel.Sitecore.Pipelines.GetChromeData
{
    public abstract class GetChromeDataBase: GetPlaceholderChromeData
    {
        public override void Process(GetChromeDataArgs args)
        {
            WebsiteKernalNinjectKernelContainer.Inject(this);
            this.DoGetChromeData(args);
        }

        protected abstract void DoGetChromeData(GetChromeDataArgs args);
    }
}
