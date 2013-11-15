// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseHydrator.cs" company="Gravypowered">
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
//   The response hydrator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service
{
    using System.Collections.Generic;

    using Gravyframe.Service.Messages;

    /// <summary>
    /// The response hydrator.
    /// </summary>
    /// <typeparam name="TRequest">
    /// The type of the request, must be of type of Gravyframe.Service.Messages.Request
    /// </typeparam>
    /// <typeparam name="TResponse">
    /// The type of the response, must be of type of Gravyframe.Service.Messages.Response
    /// </typeparam>
    public abstract class ResponseHydrator<TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response
    {
        /// <summary>
        /// The validate response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public abstract IEnumerable<string> ValidateResponse(TRequest request);

        /// <summary>
        /// The populate response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="response">
        /// The response.
        /// </param>
        public abstract void PopulateResponse(TRequest request, TResponse response);
    }
}
