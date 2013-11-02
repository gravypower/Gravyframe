using System.Collections.Generic;
using System.Linq;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service
{
    public class ResponseHydrogenationRunner<TRequest, TResponse> 
        where TRequest : Request
        where TResponse : Response, new()
    {
        private readonly IEnumerable<ResponseHydrator<TRequest, TResponse>> _responseHydrogenationTasks;
        private readonly TRequest _request;
        private readonly List<string> _errorList; 

        public ResponseHydrogenationRunner(IResponseHydrogenationTaskList<TRequest, TResponse> responseHydrogenationTasks, TRequest request)
        {
            _responseHydrogenationTasks = responseHydrogenationTasks;
            _request = request;
            _errorList = new List<string>();
        }

        public TResponse RunTasks()
        {
            var response = new TResponse();

            foreach (var task in _responseHydrogenationTasks.Where(ValidateResponse))
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

            if (response.Code == ResponceCodes.Unknown)
            {
                response.Code = ResponceCodes.Success;
            }
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
