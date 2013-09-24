using System.Collections.Generic;
using System.Linq;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service
{
    public class ResponseHydratationRunner<TRequest, TResponse> 
        where TRequest : Request
        where TResponse : Response, new()
    {
        private readonly IEnumerable<ResponseHydrator<TRequest, TResponse>> _responseHydratationTasks;
        private readonly TRequest _request;
        private readonly List<string> _errorList; 

        public ResponseHydratationRunner(IEnumerable<ResponseHydrator<TRequest, TResponse>> responseHydratationTasks, TRequest request)
        {
            _responseHydratationTasks = responseHydratationTasks;
            _request = request;
            _errorList = new List<string>();
        }

        public TResponse RunTasks()
        {
            var response = new TResponse();

            foreach (var task in _responseHydratationTasks.Where(ValidateResponse))
                PopulateResponse(response, task);

            AddErrors(response);

            return response;
        }

        private bool ValidateResponse(ResponseHydrator<TRequest, TResponse> responseHydrator)
        {
            var errors = responseHydrator.ValidateResponse(_request).ToArray();
            if (errors.Any())
            {
                _errorList.AddRange(errors);
                return false;
            }
            
            return true;
        }

        private void PopulateResponse(TResponse response, ResponseHydrator<TRequest, TResponse> responseHydrator)
        {
            responseHydrator.PopulateResponse(_request, response);
            response.Code = ResponceCodes.Success;
        }

        private void AddErrors(TResponse response)
        {
            if (!IsResponseFailure(response)) return;

            response.Errors = _errorList;
            response.Code = ResponceCodes.Failure;
        }

        private static bool IsResponseFailure(TResponse response)
        {
            return !response.IsSuccess();
        }
    }
}
