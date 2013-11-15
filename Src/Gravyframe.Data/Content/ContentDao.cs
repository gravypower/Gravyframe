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



namespace Gravyframe.Data.Content
{
    using System.Collections.Generic;

    /// <summary>
    /// The content dao.
    /// </summary>
    /// <typeparam name="TContent">
    /// The type of Content, must be of type Gravyframe.Models.Content
    /// </typeparam>
    public abstract class ContentDao<TContent> where TContent : Models.Content
    {
        /// <summary>
        /// The get content.
        /// </summary>
        /// <param name="contentId">
        /// The content id.
        /// </param>
        /// <returns>
        /// The <see cref="TContent"/>.
        /// </returns>
        public abstract TContent GetContent(string contentId);

        /// <summary>
        /// The get content by category.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see>
        ///     <cref>IEnumerable</cref>
        /// </see>
        ///     .
        /// </returns>
        public abstract IEnumerable<TContent> GetContentByCategory(string categoryId);
    }
}
