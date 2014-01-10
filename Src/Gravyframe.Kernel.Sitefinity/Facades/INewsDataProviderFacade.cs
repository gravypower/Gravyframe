// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INewsDataProviderFacade.cs" company="Gravypowered">
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
//   Defines the INewsDataProviderFacade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Kernel.Sitefinity.Facades
{
    using System;

    using Telerik.Sitefinity.News.Model;

    /// <summary>
    /// The NewsDataProviderFacade interface.
    /// </summary>
    public interface INewsDataProviderFacade
    {
        /// <summary>
        /// The get news item.
        /// </summary>
        /// <param name="id">
        /// The id of the news.
        /// </param>
        /// <returns>
        /// The <see cref="NewsItem"/>.
        /// </returns>
        NewsItem GetNewsItem(Guid id);
    }
}
