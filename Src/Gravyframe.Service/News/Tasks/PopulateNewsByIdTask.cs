using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.News.Tasks
{
    public class PopulateNewsByIdTask : NewsTask
    {
        public PopulateNewsByIdTask(INewsConstants newsConstants) : base(newsConstants)
        {
        }

        public override void PopulateResponse(NewsRequest request, NewsResponse response)
        {
            if (String.IsNullOrEmpty(request.NewsId))
            {
                response.Code = ResponceCodes.Failure;
                response.Errors.Add(NewsConstants.NewsIdError);
            }
        }
    }
}
