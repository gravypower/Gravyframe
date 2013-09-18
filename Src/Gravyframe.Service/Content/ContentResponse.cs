using System.Collections.Generic;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentResponse
    {
        public GravyResponceCodes ResponceCode { get; set; }

        public List<string> Errors { get; set; }

        public Models.Content Content { get; set; }

        public ContentResponse()
        {
            Errors = new List<string>();
        }
    }
}
