// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentDao.cs" company="Gravypowered">
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
//   Defines the ContentDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Data.Umbraco.Content
{
    using System.Collections.Generic;

    using Gravyframe.Data.Content;
    using Gravyframe.Models.Umbraco;

    /// <summary>
    /// The content dao.
    /// </summary>
    public class ContentDao : ContentDao<UmbracoContent>
    {
        /// <summary>
        /// The get content.
        /// </summary>
        /// <param name="contentId">
        /// The content id.
        /// </param>
        /// <returns>
        /// The <see cref="UmbracoContent"/>.
        /// </returns>
        public override UmbracoContent GetContent(string contentId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The get content by category.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<UmbracoContent> GetContentByCategory(string categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}
