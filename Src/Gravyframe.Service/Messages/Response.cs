// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="Gravypowered">
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
//   Defines the Response type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.Messages
{
    using System.Collections.Generic;

    /// <summary>
    /// The response.
    /// </summary>
    public abstract class Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        protected Response()
        {
            this.Errors = new List<string>();
            this.Code = ResponseCodes.Unknown;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// A response code letting you know how the request went.
        /// </value>
        public ResponseCodes Code { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// Any errors the may have been encountered. 
        /// </value>
        public List<string> Errors { get; set; }

        /// <summary>
        /// The is success.
        /// </summary>
        /// <returns>
        /// If the request was a success.
        /// </returns>
        public bool IsSuccess()
        {
            return this.Code == ResponseCodes.Success;
        }
    }
}
