﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopulateContentByIdResponseHydrator.cs" company="Gravypowered">
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
//   Defines the PopulateContentByIdResponseHydrator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.Content.Tasks
{
    using System.Collections.Generic;

    using Gravyframe.Configuration;
    using Gravyframe.Data.Content;

    /// <summary>
    /// The populate content by id response hydrator.
    /// </summary>
    public class PopulateContentByIdResponseHydrator : ContentResponseHydrator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PopulateContentByIdResponseHydrator"/> class.
        /// </summary>
        /// <param name="contentDao">
        /// The content dao.
        /// </param>
        /// <param name="contentConfiguration">
        /// The content configuration.
        /// </param>
        public PopulateContentByIdResponseHydrator(ContentDao<Models.Content> contentDao, IContentConfiguration contentConfiguration)
            : base(contentDao, contentConfiguration)
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
            response.Content = ContentDao.GetContent(request.ContentId);
        }

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
        public override IEnumerable<string> ValidateResponse(ContentRequest request)
        {
            if (string.IsNullOrEmpty(request.ContentId))
            {
                return new List<string> { ContentConfiguration.ContentCategoryIdError };
            }

            return new List<string>();
        }
    }
}