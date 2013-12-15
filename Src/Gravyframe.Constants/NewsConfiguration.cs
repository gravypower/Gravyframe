// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsConfiguration.cs" company="Gravypowered">
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
//   Defines the NewsConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Configuration
{
    /// <summary>
    /// The news configuration.
    /// </summary>
    public abstract class NewsConfiguration : INewsConfiguration
    {
        /// <summary>
        /// Gets the news id error.
        /// </summary>
        /// <value>
        /// The news id error.
        /// </value>
        public virtual string NewsIdError
        {
            get { return "News Id error"; }
        }

        /// <summary>
        /// Gets the news category id error.
        /// </summary>
        /// <value>
        /// The news category id error.
        /// </value>
        public virtual string NewsCategoryIdError
        {
            get { return "News Category Id error"; }
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

        /// <summary>
        /// Gets the null news error.
        /// </summary>
        /// <value>
        /// The null news error.
        /// </value>
        public virtual string NullNewsError
        {
            get { return "Null News error"; }
        }
    }
}
