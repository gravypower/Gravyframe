using System;
using System.Collections.Generic;
using System.Linq;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service
{
    public abstract class Service<TRequest, TResponse, TArgumentNullException>
        where TRequest : Request
        where TResponse : Response, new()
        where TArgumentNullException : Service<TRequest, TResponse, TArgumentNullException>.NullRequestException, new()
    {
        private readonly IEnumerable<Task<TRequest, TResponse>> _tasks;

        protected Service(IEnumerable<Task<TRequest, TResponse>> tasks)
        {
            _tasks = tasks;
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
            var response = new TResponse();

            foreach (var task in _tasks)
            {
                task.PopulateResponse(request, response);
            }

            if(response.Code == ResponceCodes.Success)
                response.Errors.Clear();

            return response;
        }


        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
             
        }
    }
}
