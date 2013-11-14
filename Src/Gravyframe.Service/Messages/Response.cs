using System.Collections.Generic;

namespace Gravyframe.Service.Messages
{
    public abstract class Response
    {
        public ResponseCodes Code { get; set; }
        public List<string> Errors { get; set; }

        protected Response()
        {
            Errors = new List<string>();
            Code = ResponseCodes.Unknown;
        }

        public bool IsSuccess()
        {
            return Code == ResponseCodes.Success;
        }
    }
}
