using System;
using System.Collections.Generic;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service
{
    public abstract class Service<TRequest, TResponse, TArgumentNullException>
        where TRequest : Request
        where TResponse : Response, new()
        where TArgumentNullException : Service<TRequest, TResponse, TArgumentNullException>.NullRequestException, new()
    {
        private readonly IEnumerable<ResponseHydrator<TRequest, TResponse>> _responseHydrogenationTasks;

        protected Service(IEnumerable<ResponseHydrator<TRequest, TResponse>> responseHydrogenationTasks)
        {
            _responseHydrogenationTasks = responseHydrogenationTasks;
        }

        public TResponse Get(TRequest request)
        {
            GuardRequest(request);
            return CreateResponse(request);
        }

        protected virtual void GuardRequest(TRequest request)
        {
            if (request == null)
                throw new TArgumentNullException();
        }
        
        protected TResponse CreateResponse(TRequest request)
        {
            return new ResponseHydrogenationRunner<TRequest, TResponse>(_responseHydrogenationTasks, request).RunTasks();
        }

        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
        }
    }
}
