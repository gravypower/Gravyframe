// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopulateContentByCategoryIdResponseHydrator.cs" company="Gravypowered">
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
//   The populate content by category id response hydrator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.Content.Tasks
{
    using System.Collections.Generic;

    using Gravyframe.Configuration;
    using Gravyframe.Data.Content;

    /// <summary>
    /// The populate content by category id response hydrator.
    /// </summary>
    public class PopulateContentByCategoryIdResponseHydrator : ContentResponseHydrator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PopulateContentByCategoryIdResponseHydrator"/> class.
        /// </summary>
        /// <param name="contentDao">
        /// The content dao.
        /// </param>
        /// <param name="contentConfiguration">
        /// The content configuration.
        /// </param>
        public PopulateContentByCategoryIdResponseHydrator(ContentDao<Models.Content> contentDao, IContentConfiguration contentConfiguration) : base(contentDao, contentConfiguration)
        {
        }

        /// <summary>
        /// The populate response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="response">
        /// The response.
        /// </param>
        public override void PopulateResponse(ContentRequest request, ContentResponse response)
        {
            response.ContentList = ContentDao.GetContentByCategory(request.CategoryId);         
        }

        /// <summary>
        /// The validate response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<string> ValidateResponse(ContentRequest request)
        {
            if (string.IsNullOrEmpty(request.CategoryId))
            {
                return new List<string> { ContentConfiguration.ContentIdError };
            }

            return new List<string>();
        }
    }
}
