// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseHydrogenationRunner.cs" company="Gravypowered">
//   Copyright 2013 Aaron Job
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   The response hydrogenation runner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Gravyframe.Service.Messages;

    /// <summary>
    /// The response hydrogenation runner.
    /// </summary>
    /// <typeparam name="TRequest">
    /// The type of the request, must be of type of Gravyframe.Service.Messages.Request
    /// </typeparam>
    /// <typeparam name="TResponse">
    /// The type of the response, must be of type of Gravyframe.Service.Messages.Response
    /// </typeparam>
    public class ResponseHydrogenationRunner<TRequest, TResponse> 
        where TRequest : Request
        where TResponse : Response, new()
    {
        private readonly IEnumerable<ResponseHydrator<TRequest, TResponse>> responseHydrogenationTasks;
        private readonly TRequest request;
        private readonly List<string> errorList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseHydrogenationRunner{TRequest,TResponse}"/> class.
        /// </summary>
        /// <param name="responseHydrogenationTasks">
        /// The response hydrogenation tasks.
        /// </param>
        /// <param name="request">
        /// The request.
        /// </param>
        public ResponseHydrogenationRunner(IResponseHydrogenationTaskList<TRequest, TResponse> responseHydrogenationTasks, TRequest request)
        {
            this.responseHydrogenationTasks = responseHydrogenationTasks;
            this.request = request;
            this.errorList = new List<string>();
        }

        /// <summary>
        /// The run tasks.
        /// </summary>
        /// <returns>
        /// The <see cref="TResponse"/>.
        /// </returns>
        public TResponse RunTasks()
        {
            var response = new TResponse();

            foreach (var task in this.responseHydrogenationTasks.Where(this.ValidateResponse))
            {
                this.PopulateResponse(response, task);
            }

            this.AddErrors(response);

            return response;
        }

        private static bool IsResponseFailure(TResponse response)
        {
            return !response.IsSuccess();
        }

        private bool ValidateResponse(ResponseHydrator<TRequest, TResponse> responseHydrator)
        {
            var errors = responseHydrator.ValidateResponse(this.request).ToArray();
            if (errors.Any())
            {
                this.errorList.AddRange(errors);
                return false;
            }
            
            return true;
        }

        private void PopulateResponse(TResponse response, ResponseHydrator<TRequest, TResponse> responseHydrator)
        {
            responseHydrator.PopulateResponse(this.request, response);

            if (response.Code == ResponseCodes.Unknown)
            {
                response.Code = ResponseCodes.Success;
            }
        }

        private void AddErrors(TResponse response)
        {
            if (!IsResponseFailure(response))
            {
                return;
            }

            response.Errors = this.errorList;
            response.Code = ResponseCodes.Failure;
        }
    }
}
