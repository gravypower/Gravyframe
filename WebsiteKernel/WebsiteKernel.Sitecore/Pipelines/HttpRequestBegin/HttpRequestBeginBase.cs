using System;
using System.Linq;
using Sitecore.Pipelines.HttpRequest;
using WebsiteKernel;

namespace WebsiteKernel.Sitecore.Pipelines.HttpRequestBegin
{
    public abstract class HttpRequestBeginBase : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            WebsiteKernalNinjectKernelContainer.Inject(this);
            this.DoProcessRequest(args);
        }

        protected abstract void DoProcessRequest(HttpRequestArgs args);

    }
}
