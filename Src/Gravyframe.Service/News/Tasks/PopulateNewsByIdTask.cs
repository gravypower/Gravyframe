using System;
using System.Collections.Generic;

namespace Gravyframe.Service.News.Tasks
{
    public class PopulateNewsByIdTask : NewsTask
    {
        public PopulateNewsByIdTask(INewsConstants newsConstants) : base(newsConstants)
        {
        }

        public override void PopulateResponse(NewsRequest request, NewsResponse response)
        {
        }

        public override IEnumerable<string> ValidateResponse(NewsRequest request)
        {
            if (String.IsNullOrEmpty(request.NewsId))
                return new List<string>
                    {
                        NewsConstants.NewsIdError
                    };
            return new List<string>();
        }
    }
}
