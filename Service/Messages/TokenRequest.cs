using System.Runtime.Serialization;
using Service.MessageBase;

namespace Service.Messages
{
    /// <summary>
    /// Respresents a security token request message from client to web service.
    /// </summary>
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class TokenRequest : RequestBase
    {
        // Nothing needed here...
    }
}

