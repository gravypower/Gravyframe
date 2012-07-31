using System;
using System.Linq;
using Sitecore.Pipelines.GetRenderingDatasource;

namespace WebsiteKernel.Sitecore.Pipelines.GetRenderingDatasource
{
    public abstract class GetRenderingDatasourceBase
    {
       public void Process(GetRenderingDatasourceArgs args)
        {
            WebsiteKernalNinjectKernelContainer.Inject(this);
            this.DoGetRenderingDatasource(args);
        }

       protected abstract void DoGetRenderingDatasource(GetRenderingDatasourceArgs args);
    }
}
