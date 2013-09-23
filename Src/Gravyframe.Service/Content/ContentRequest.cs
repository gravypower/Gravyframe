using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentRequest:Request
    {
        public string ContentId { get; set; }
        public string CategoryId { get; set; }
    }
}
