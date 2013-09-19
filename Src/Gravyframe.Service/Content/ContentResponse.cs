using System.Collections.Generic;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentResponse : Response
    {
        public Models.Content Content { get; set; }
        public IEnumerable<Models.Content> ContentList { get; set; }
    }
}
