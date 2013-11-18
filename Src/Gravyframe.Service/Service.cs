// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service.cs" company="Gravypowered">
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
//   Defines the Service type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service
{
    using System;

    using Gravyframe.Service.Messages;

    /// <summary>
    /// The service.
    /// </summary>
    /// <typeparam name="TRequest">
    /// The type of the request, must be of type of Gravyframe.Service.Messages.Request
    /// </typeparam>
    /// <typeparam name="TResponse">
    /// The type of the response, must be of type of Gravyframe.Service.Messages.Response
    /// </typeparam>
    /// <typeparam name="TArgumentNullException">
    ///  Exception of type NullRequestException
    /// </typeparam>
    public abstract class Service<TRequest, TResponse, TArgumentNullException> : IService
        where TRequest : Request
        where TResponse : Response, new()
        where TArgumentNullException : Service<TRequest, TResponse, TArgumentNullException>.NullRequestException, new()
    {
        private readonly IResponseHydrogenationTaskList<TRequest, TResponse> responseHydrogenationTasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TRequest,TResponse,TArgumentNullException}"/> class.
        /// </summary>
        /// <param name="responseHydrogenationTasks">
        /// The response hydrogenation tasks.
        /// </param>
        protected Service(IResponseHydrogenationTaskList<TRequest, TResponse> responseHydrogenationTasks)
        {
            this.responseHydrogenationTasks = responseHydrogenationTasks;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="TResponse"/>.
        /// </returns>
        public TResponse Get(TRequest request)
        {
            this.GuardRequest(request);
            return this.CreateResponse(request);
        }

        /// <summary>
        /// The guard request.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <exception>
        ///     This exception is thrown is the request is null
        ///     <cref>TArgumentNullException</cref>
        /// </exception>
        public virtual void GuardRequest(TRequest request)
        {
            if (request == null)
            {
                throw new TArgumentNullException();
            }
        }

        /// <summary>
        /// The create response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="TResponse"/>.
        /// </returns>
        public TResponse CreateResponse(TRequest request)
        {
            return new ResponseHydrogenationRunner<TRequest, TResponse>(this.responseHydrogenationTasks, request).RunTasks();
        }

        /// <summary>
        /// The null request exception.
        /// </summary>
        [Serializable]
        public abstract class NullRequestException : ArgumentNullException
        {
        }
    }
}
