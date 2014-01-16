// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentConfiguration.cs" company="Gravypowered">
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
//   Defines the ContentConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Configuration
{
    /// <summary>
    /// The content configuration.
    /// </summary>
    public class ContentConfiguration : IContentConfiguration
    {
        /// <summary>
        /// Gets the content id error.
        /// </summary>
        /// <value>
        /// The content id error.
        /// </value>
        public string ContentIdError
        {
            get { return "Content Id error"; }
        }

        /// <summary>
        /// Gets the content category id error.
        /// </summary>
        /// <value>
        /// The content category id error.
        /// </value>
        public string ContentCategoryIdError
        {
            get { return "Content Category Id error"; }
        }

        /// <summary>
        /// Gets the default list size.
        /// </summary>
        /// <value>
        /// The default list size.
        /// </value>
        public virtual int DefaultListSize
        {
            get { return 10; }
        }
    }
}
