using System.Collections.Generic;

namespace Gravyframe.Service.Messages
{
    public class Response
    {
        public ResponceCodes ResponceCode { get; set; }
        public List<string> Errors { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }

        public bool IsRequestASuccess()
        {
            return ResponceCode == ResponceCodes.Success;
        }
    }
}
