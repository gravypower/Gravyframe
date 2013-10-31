using System;
using System.Collections.Generic;

namespace Gravyframe.Service.News
{
    public class NewsService<TNews> : Service<NewsRequest, NewsResponse<TNews>, NewsService<TNews>.NullNewsRequestException>
        where TNews : Models.News
    {
        [Serializable]
        public class NullNewsRequestException : NullRequestException
        {
        }

        public NewsService(IEnumerable<ResponseHydrator<NewsRequest, NewsResponse<TNews>>> responseHydrogenationTasks) : base(responseHydrogenationTasks)
        {
        }
    }
}
