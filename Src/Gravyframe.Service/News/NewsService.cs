﻿using System;
using System.Collections.Generic;

namespace Gravyframe.Service.News
{
    public class NewsService : Service<NewsRequest, NewsResponse, NewsService.NullNewsRequestException>
    {
        [Serializable]
        public class NullNewsRequestException : NullRequestException
        {
        }

        public NewsService(IEnumerable<ResponseHydrator<NewsRequest, NewsResponse>> responseHydrogenationTasks) : base(responseHydrogenationTasks)
        {
        }
    }
}
