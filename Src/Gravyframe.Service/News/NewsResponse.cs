using Gravyframe.Service.Messages;

namespace Gravyframe.Service.News
{
    public class NewsResponse : Response
    {
        public Models.News News { get; set; }
    }
}
