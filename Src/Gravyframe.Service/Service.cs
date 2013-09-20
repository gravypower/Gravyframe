using System;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service
{
    public abstract class Service<TRequest, TResponce, TArgumentNullException>
        where TRequest : Request
        where TResponce : Response
        where TArgumentNullException : Service<TRequest, TResponce, TArgumentNullException>.NullRequestException, new()
    {
        public TResponce Get(TRequest request)
        {
            GuardRequest(request);

            CustomGardRequest(request);

            var responce = ValidateRequest(request);

            if (!responce.IsRequestASuccess())
                return responce;

            return CreateResponce(request, responce);
        }

        private static void GuardRequest(TRequest request)
        {
            if (request == null)
                throw new TArgumentNullException();
        }

        protected virtual void CustomGardRequest(TRequest request)
        {
        }

        protected abstract TResponce ValidateRequest(TRequest request);
        protected abstract TResponce CreateResponce(TRequest request, TResponce responce);

        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
             
        }
    }
}
