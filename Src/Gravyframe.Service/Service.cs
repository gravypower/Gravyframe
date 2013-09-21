using System;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service
{
    public abstract class Service<TRequest, TResponse, TArgumentNullException>
        where TRequest : Request
        where TResponse : Response, new()
        where TArgumentNullException : Service<TRequest, TResponse, TArgumentNullException>.NullRequestException, new()
    {
        public TResponse Get(TRequest request)
        {
            GuardRequest(request);
            return GetResponce(request);
        }

        protected virtual void GuardRequest(TRequest request)
        {
            if (request == null)
                throw new TArgumentNullException();
        }

        protected abstract TResponse ValidateRequest(TRequest request);
        protected abstract TResponse CreateResponce(TRequest request);

        private TResponse GetResponce(TRequest request)
        {
            var responce = ValidateRequest(request);

            if (!responce.IsRequestASuccess())
                return responce;
            
            return CreateResponce(request);   
        }

        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
             
        }
    }
}
