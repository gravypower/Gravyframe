using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Pipelines.HttpRequest;

namespace WebsiteKernel.Sitecore.Pipelines.HttpRequestEnd
{
    public abstract class HttpRequestEndBase: HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            WebsiteKernalNinjectKernelContainer.Inject(this);
            this.DoProcessRequest(args);
        }

        protected abstract void DoProcessRequest(HttpRequestArgs args);
    }
}
