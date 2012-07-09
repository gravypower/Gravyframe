using System.Runtime.Serialization;
using Service.MessageBase;

namespace Service.Messages
{
    /// <summary>
    /// Represents a security token response message from web service to client.
    /// </summary>
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class TokenResponse : ResponseBase
    {
        /// <summary>
        /// Default Constructor for TokenResponse.
        /// </summary>
        public TokenResponse() { }

        /// <summary>
        /// Overloaded Constructor for TokenResponse. Sets CorrelationId.
        /// </summary>
        /// <param name="correlationId"></param>
        public TokenResponse(string correlationId) : base(correlationId) { }

        /// <summary>
        /// Security token returned to the consumer
        /// </summary>
        [DataMember]
        public string AccessToken;
    }
}

