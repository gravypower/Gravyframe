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
            return IsNotContentIdEmpty() || IsNotCategoryIdEmpty();
        }

        private bool IsNotCategoryIdEmpty()
        {
            return !String.IsNullOrEmpty(CategoryId);
        }

        private bool IsNotContentIdEmpty()
        {
            return !String.IsNullOrEmpty(ContentId);
        }
    }
}
