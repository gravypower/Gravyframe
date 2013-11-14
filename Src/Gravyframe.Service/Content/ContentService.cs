// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentService.cs" company="Gravypowered">
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
//   Defines the ContentService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.Content
{
    using System;

    /// <summary>
    /// The content service.
    /// </summary>
    public class ContentService : Service<ContentRequest, ContentResponse, ContentService.NullContentRequestException>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentService"/> class.
        /// </summary>
        /// <param name="responseHydrogenationTasks">
        /// The response hydrogenation tasks.
        /// </param>
        public ContentService(
            IResponseHydrogenationTaskList<ContentRequest, ContentResponse> responseHydrogenationTasks)
            : base(responseHydrogenationTasks)
        {
        }

        /// <summary>
        /// The null content request exception.
        /// </summary>
        [Serializable]
        public class NullContentRequestException : NullRequestException
        {
        }
    }
}
