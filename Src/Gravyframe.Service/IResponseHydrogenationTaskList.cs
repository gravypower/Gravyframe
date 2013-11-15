// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResponseHydrogenationTaskList.cs" company="Gravypowered">
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
//   Defines the IResponseHydrogenationTaskList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service
{
    using System.Collections.Generic;

    using Gravyframe.Service.Messages;

    /// <summary>
    /// The ResponseHydrogenationTaskList interface.
    /// </summary>
    /// <typeparam name="TRequest">
    ///     The type of Request, must be of type Gravyframe.Service.Messages.Request
    /// </typeparam>
    /// <typeparam name="TResponse">
    ///     The type of Response, must be of type Gravyframe.Service.Messages.Response
    /// </typeparam>
    public interface IResponseHydrogenationTaskList<TRequest, TResponse> : IEnumerable<ResponseHydrator<TRequest, TResponse>>
        where TRequest : Request
        where TResponse : Response
    {
    }
}
