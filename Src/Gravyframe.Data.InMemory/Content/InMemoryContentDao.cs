// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryContentDao.cs" company="Gravypowered">
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
//   Defines the InMemoryContentDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Data.InMemory.Content
{
    using System.Collections.Generic;

    using Gravyframe.Data.Content;

    /// <summary>
    /// The in memory content dao.
    /// </summary>
    public class InMemoryContentDao : ContentDao<Models.Content>
    {
        private readonly List<Models.Content> contentList;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryContentDao"/> class.
        /// </summary>
        public InMemoryContentDao()
        {
            this.contentList = new List<Models.Content>();

            for (int i = 0; i < 100; i++)
            {
               this.contentList.Add(new Models.Content { Title = "Test", Body = "Test" });
            }
        }

        /// <summary>
        /// The get content.
        /// </summary>
        /// <param name="contentId">
        /// The content id.
        /// </param>
        /// <returns>
        /// The <see cref="Content"/>.
        /// </returns>
        public override Models.Content GetContent(string contentId)
        {
            return new Models.Content { Title = "Test", Body = "Test" };
        }

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
        public override IEnumerable<Models.Content> GetContentByCategory(string categoryId)
        {
            return this.contentList;
        }
    }
}
