// --------------------------------------------------------------------------------------------------------------------
// <copyright file="News.cs" company="Gravypowered">
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
//   Defines the News type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Models
{
    /// <summary>
    /// The base model that represents news.  Any new implementation will need to inherit from this class.
    /// </summary>
    public class News : INews
    {
        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence that this item was added to a collection.  Will be 0 if is not part of a collection.
        /// </value>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title of the news.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body of the news.
        /// </value>
        public string Body { get; set; }
    }
}
