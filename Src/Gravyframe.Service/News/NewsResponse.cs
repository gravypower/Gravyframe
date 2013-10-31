using System.Collections.Generic;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.News
{
    public class NewsResponse<TNews> : Response
        where TNews : Models.News
    {
        public TNews News { get; set; }

        public IEnumerable<TNews> NewsList { get; set; }
    }
}
