using System.Collections.Generic;

namespace Gravyframe.Service.Messages
{
    public abstract class Response
    {
        public ResponceCodes Code { get; set; }
        public List<string> Errors { get; set; }

        protected Response()
        {
            Errors = new List<string>();
            Code = ResponceCodes.Unknown;
        }

        public bool IsSuccess()
        {
            return Code == ResponceCodes.Success;
        }
    }
}
