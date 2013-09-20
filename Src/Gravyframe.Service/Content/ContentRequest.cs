using System;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentRequest:Request
    {
        public string ContentId { get; set; }
        public string CategoryId { get; set; }

        internal override bool IsRequestValid()
        {
            return IsContentIdValid() && IsCategoryIdValid();
        }

        private bool IsCategoryIdValid()
        {
            return String.IsNullOrEmpty(CategoryId);
        }

        private bool IsContentIdValid()
        {
            return String.IsNullOrEmpty(ContentId);
        }
    }
}
