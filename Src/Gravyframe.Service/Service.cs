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
        private readonly IEnumerable<ResponseHydrator<TRequest, TResponse>> _responseHydratationTasks;

        protected Service(IEnumerable<ResponseHydrator<TRequest, TResponse>> responseHydratationTasks)
        {
            _responseHydratationTasks = responseHydratationTasks;
        }

        public TResponse Get(TRequest request)
        {
            GuardRequest(request);
            return CreateResponce(request);
        }

        protected virtual void GuardRequest(TRequest request)
        {
            if (request == null)
                throw new TArgumentNullException();
        }
        
        protected TResponse CreateResponce(TRequest request)
        {
            return new ResponseHydratationRunner<TRequest, TResponse>(_responseHydratationTasks, request).RunTasks();
        }

        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
        }
    }
}
