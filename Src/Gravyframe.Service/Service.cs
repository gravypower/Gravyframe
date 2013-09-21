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

            var responce = ValidateRequest(request);
            return !responce.IsRequestASuccess() ? responce : CreateResponce(request, responce);
        }

        private static void GuardRequest(TRequest request)
        {
            if (request == null)
                throw new TArgumentNullException();
        }

        protected abstract TResponce ValidateRequest(TRequest request);
        protected abstract TResponce CreateResponce(TRequest request, TResponce responce);

        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
             
        }
    }
}
