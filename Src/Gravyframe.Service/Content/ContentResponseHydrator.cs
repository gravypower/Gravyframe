// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentResponseHydrator.cs" company="Gravypowered">
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
//   Defines the ContentResponseHydrator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Service.Content
{
    using Gravyframe.Configuration;
    using Gravyframe.Data.Content;

    /// <summary>
    /// The content response hydrator.
    /// </summary>
    public abstract class ContentResponseHydrator : ResponseHydrator<ContentRequest, ContentResponse>
    {
        /// <summary>
        /// The content dao.
        /// </summary>
        protected readonly ContentDao<Models.Content> ContentDao;

        /// <summary>
        /// The content configuration.
        /// </summary>
        protected readonly IContentConfiguration ContentConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentResponseHydrator"/> class.
        /// </summary>
        /// <param name="contentDao">
        /// The content dao.
        /// </param>
        /// <param name="contentConfiguration">
        /// The content configuration.
        /// </param>
        protected ContentResponseHydrator(ContentDao<Models.Content> contentDao, IContentConfiguration contentConfiguration)
        {
            this.ContentDao = contentDao;
            this.ContentConfiguration = contentConfiguration;
        }
    }
}
