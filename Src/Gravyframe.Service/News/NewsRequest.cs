using Gravyframe.Service.Messages;

namespace Gravyframe.Service.News
{
    public class NewsRequest:Request
    {
        public string NewsId { get; set; }

        public string CategoryId { get; set; }
    }
}
