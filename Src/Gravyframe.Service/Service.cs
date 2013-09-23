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
            var errorList = new List<string>();
            foreach (var task in _tasks)
            {
                var errors = task.ValidateResponse(request).ToArray();
                if (errors.Any() && response.Code != ResponceCodes.Success)
                {
                    errorList.AddRange(errors);
                }
                else
                {
                    task.PopulateResponse(request, response);
                    response.Code = ResponceCodes.Success;
                }
            }

            if (response.Code == ResponceCodes.Failure)
            {
                response.Errors = errorList;
            }

            return response;
        }


        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
             
        }
    }
}
