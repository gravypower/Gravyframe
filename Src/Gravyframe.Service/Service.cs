using System;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service
{
    public abstract class Service<TRequest, TResponce>
        where TRequest : Request
        where TResponce : Response
    {
        public abstract TResponce Get(TRequest request);

        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
             
        }
    }
}
