using System.Collections.Generic;

namespace Gravyframe.Service.Messages
{
    public class Response
    {
        public ResponceCodes Code { get; set; }
        public List<string> Errors { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }

        public bool IsRequestASuccess()
        {
            return Code == ResponceCodes.Success;
        }
    }
}
