using System;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.News
{
    public class NewsRequest:Request
    {
        internal override bool IsRequestValid()
        {
            return !String.IsNullOrEmpty(NewsId);
        }

        public string NewsId { get; set; }
    }
}
